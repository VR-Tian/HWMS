using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using HWMS.Application.Interfaces;
using HWMS.Application.Services;
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
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemoryCache, MemoryCache>();

            services.AddScoped<IRequestHandler<RegisterOrderCommand, Unit>, OrderCommandHandler>();
            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


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
