using System;
using HWMS.DoMain.Core.Commands;

namespace HWMS.DoMain.Commands.Order
{
    /// <summary>
    /// 定义一个抽象的order命令模型
    /// 继承 Command
    /// 这个模型主要作用就是用来创建命令动作的，不是用来实例化存数据的，所以是一个抽象类
    /// </summary>
    public abstract class OrderCommand : Command
    {
        public Guid Id { get; protected set; }

        public string OrderNumber { get; protected set; }


    }
}