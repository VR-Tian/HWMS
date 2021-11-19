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
using HWMS.DoMain.Interfaces.Oracle;
using HWMS.Infrastructure;
using HWMS.Infrastructure.Bus;
using HWMS.Infrastructure.Contexts;
using HWMS.Infrastructure.Contexts.OracleContext;
using HWMS.Infrastructure.Repository;
using HWMS.Infrastructure.Repository.Oracle;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HWMS.API.Extension
{
    /// <summary>
    /// 注册注入实例对象的拓展
    /// </summary>
    public static class InstanceDIExtensions
    {
        /// <summary>
        /// 注入项目所依赖的实例对象
        /// </summary>
        /// <param name="services"></param>
        public static void AddInstances(this IServiceCollection services)
        {
            #region Scoped
            //services.AddScoped<IAuthorizationHandler, CustomAuthorizationHandler>();
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
            services.AddScoped<INavigationMenuRepository, NavigationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMemoryCache, MemoryCache>();

            services.AddScoped<IRequestHandler<RegisterOrderCommand, Unit>, OrderCommandHandler>();
            services.AddScoped<INotificationHandler<OrderRegisteredEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            #endregion
        }
    }
}
