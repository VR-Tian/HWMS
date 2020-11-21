using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using HWMS.DoMain.Core.Bus;
using HWMS.DoMain.Core.Commands;
using HWMS.DoMain.Core.Events;
using MediatR;

namespace HWMS.Infrastructure.Bus
{
    /// <summary>
    /// 一个密封类，实现我们的中介记忆总线
    /// </summary>
    public sealed class InMemoryBus : IMediatorHandler
    {

        private readonly IMediator _Mediator;

        /// <summary>
        /// 服务工厂
        /// </summary>
        private readonly ServiceFactory _ServiceFactory;

        private static readonly ConcurrentDictionary<Type, object> _requestHandlers = new ConcurrentDictionary<Type, object>();

        public InMemoryBus(IMediator mediator, ServiceFactory serviceFactory)
        {
            _Mediator = mediator;
            this._ServiceFactory = serviceFactory;
        }

        /// <summary>
        /// 实现我们在IMediatorHandler中定义的接口
        /// 没有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            return _Mediator.Send(command);//这里要注意下 command 对象
        }

        public Task RaiseEvent<T>(T event1) where T : Event
        {
            // MediatR中介者模式中的第二种方法，发布/订阅模式
            return _Mediator.Publish(event1);
        }
    }
}