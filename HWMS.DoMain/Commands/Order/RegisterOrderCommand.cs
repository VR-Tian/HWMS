using System;
using HWMS.DoMain.Validations.Order;

namespace HWMS.DoMain.Commands.Order
{
    public class RegisterOrderCommand : OrderCommand
    {
        public RegisterOrderCommand(string OrderNumber)
        {
            this.OrderNumber = OrderNumber;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterOrderCommandValidation().Validate(this);//命令验证
            return ValidationResult.IsValid;
        }
    }
}