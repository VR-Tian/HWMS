using System;
using FluentValidation;
using HWMS.DoMain.Commands.Order;

namespace HWMS.DoMain.Validations.Order
{
    public abstract class OrderValidation<T>:AbstractValidator<T> where T: OrderCommand
    {
        /// <summary>
        /// 验证订单号生成
        /// </summary>
        protected void ValidateOrderNumber()
        {
　　　　　　　//定义规则，c 就是当前 OrderCommand 类
            RuleFor(c => c.OrderNumber)
                .NotEmpty().WithMessage("OrderNumber不能为空")//判断不能为空，如果为空则显示Message
                .Length(2, 10).WithMessage("OrderNumber在2~10个字符之间");//定义 Name 的长度
        }
    }
}