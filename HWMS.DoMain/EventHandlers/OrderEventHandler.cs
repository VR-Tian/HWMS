using System;
using System.Threading;
using System.Threading.Tasks;
using HWMS.DoMain.Core.Commands;
using HWMS.DoMain.Events;
using MediatR;

namespace HWMS.DoMain.EventHandlers
{
    public class OrderEventHandler : INotificationHandler<OrderRegisteredEvent>
    {
        /// <summary>
        /// 新增的事件处理
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(OrderRegisteredEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        // 被修改成功后的事件处理方法
        public Task Handle()
        {
            // 恭喜您，更新成功，请牢记修改后的信息。

            return Task.CompletedTask;
        }
    }
}