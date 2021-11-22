using System.Text;
using System.Threading.Tasks;
using HWMS.Application.ViewModels;
using HWMS.API.Extension;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.IO;
using System;

namespace HWMS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "HWMS", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
            });
            services.AddInstances();
            services.AddControllers();
            services.Configure<TokenManagementOptions>(Configuration.GetSection(TokenManagementOptions.Position));
            var tokenManagement = Configuration.GetSection(TokenManagementOptions.Position).Get<TokenManagementOptions>();
            //services.AddAuthenticationCore(options => options.AddScheme<HWMSAuthenticationHandler>("myScheme", "demo scheme"));
            services.AddAuthentication(option =>
                {
                    //option.DefaultAuthenticateScheme
                    //option.DefaultSignInScheme
                    //option.DefaultChallengeScheme
                    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, "HWMSApp", options =>
                {
                    //options.Authority
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret)),
                        ValidIssuer = tokenManagement.Issuer,
                        ValidAudience = tokenManagement.Audience,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Query["token"];
                            return Task.CompletedTask;
                        }
                    };
                })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, "HWMSApp", options =>
            {
                options.Cookie.Name = "HWMSApp_Token";
                //options.SessionStore = new MemoryCacheStore();
                //options.ExpireTimeSpan = DateTime.Now.AddSeconds(30) - DateTime.Now;
                //options.Events = new CookieAuthenticationEvents();
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim("IsAdmin"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HWMS");
                });
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRecordRequestLog();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
