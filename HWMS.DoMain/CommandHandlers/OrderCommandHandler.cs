using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HWMS.DoMain.Commands.Order;
using HWMS.DoMain.Core.Bus;
using HWMS.DoMain.Core.Notifications;
using HWMS.DoMain.Events;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models;
using MediatR;

namespace HWMS.DoMain.CommandHandlers
{
    public class OrderCommandHandler : CommandHandler, IRequestHandler<RegisterOrderCommand, Unit>
    {
        // 注入仓储接口
        private readonly IOrderRepository _OrderRepository;
        // 注入总线
        private readonly IMediatorHandler _Bus;
        private IMemoryCache _Cache;

        public OrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork uow, IMediatorHandler bus, IMemoryCache cache) : base(uow, bus, cache)
        {
            this._Cache = cache;
            this._Bus = bus;
            this._OrderRepository = orderRepository;
        }

        public Task<Unit> Handle(RegisterOrderCommand message, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!message.IsValid())
            {
                // 错误信息收集
                NotifyValidationErrors(message);
                return Task.FromResult(new Unit());
            }

            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var orderRegister = new Order(Guid.NewGuid(), message.OrderNumber, DateTime.UtcNow);

            // 判断订单号是否存在
            // 这些业务逻辑，当然要在领域层中（领域命令处理程序中）进行处理
            if (_OrderRepository.GetOrderNumber(orderRegister.OrderNumber) != null)
            {
                //这里对错误信息进行发布，目前采用缓存形式
                // List<string> errorInfo = new List<string>() { "订单号已存在，请联系管理人员！" };
                // _Cache.Set("ErrorData", errorInfo);
                // return Task.FromResult(new Unit());


                //引发错误事件
                this._Bus.RaiseEvent(new DomainNotification("", "订单号已存在，请联系管理人员"));
                return Task.FromResult(new Unit());
            }

            // 持久化
            _OrderRepository.Add(orderRegister);

            // 统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                // waiting....
                this._Bus.RaiseEvent(new OrderRegisteredEvent(orderRegister.Id, orderRegister.OrderNumber));
            }

            return Task.FromResult(new Unit());
        }


        public Task<Unit> Handle()
        {
            // 同上，UpdateCommand 的处理方法
            return Task.FromResult(new Unit());
        }

        // 手动回收
        public void Dispose()
        {
            _OrderRepository.Dispose();
        }
    }
}