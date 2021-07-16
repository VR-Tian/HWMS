using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HWMS.Application.Interfaces;
using HWMS.Application.Services;
using HWMS.Application.ViewModels;
using HWMS.DoMain.CommandHandlers;
using HWMS.DoMain.Commands.Order;
using HWMS.DoMain.Core.Bus;
using HWMS.DoMain.Core.Notifications;
using HWMS.DoMain.EventHandlers;
using HWMS.DoMain.Events;
using HWMS.DoMain.Interfaces;
using HWMS.Infrastructure;
using HWMS.Infrastructure.Bus;
using HWMS.Infrastructure.Contexts;
using HWMS.Infrastructure.Contexts.OracleContext;
using HWMS.Infrastructure.Repository;
using HWMS.Web.Extension;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace HWMS.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddOptions();
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var tokenManagement = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddControllers();
            services.AddDbContext<HWMSContext>();
            services.AddDbContext<AccessContext>();
            services.AddDbContext<O_HWMSContext>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddAutoMapper(Assembly.Load("HWMS.Application"));
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemoryCache, MemoryCache>();

            services.AddScoped<IRequestHandler<RegisterOrderCommand, Unit>, OrderCommandHandler>();
            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "HWMS", Version = "v1" });
            });

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("tokenManagement", options));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret)),
                    ValidIssuer = tokenManagement.Issuer,
                    ValidAudience = tokenManagement.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                };
            });
            //             services.AddAuthorization(options =>
            //             {
            //                 var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
            //                            JwtBearerDefaults.AuthenticationScheme);
            //                 defaultAuthorizationPolicyBuilder =
            // defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
            //                 options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            //             });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy();

            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies["token"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                await next.Invoke();
            });


            // app.Run(async context =>
            // {
            //     System.Console.WriteLine("app.Run start");
            //     await context.Response.WriteAsync("Hello from 2nd delegate.");
            //     System.Console.WriteLine("app.Run end");
            // });



            //app.UseHttpsRedirection();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseRouting();
            //app.UseIsAuthorized();
           // app.UseRecordRequestLog();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HWMS");
            });
        }
    }
}
