using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using HWMS.Application.Interfaces;
using HWMS.Application.Services;
using HWMS.DoMain.Core.Bus;
using HWMS.DoMain.Interfaces;
using HWMS.Infrastructure.Bus;
using HWMS.Infrastructure.Contexts;
using HWMS.Infrastructure.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddControllers();
            services.AddDbContext<OrderContext>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddAutoMapper(Assembly.Load("HWMS.Application"));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
