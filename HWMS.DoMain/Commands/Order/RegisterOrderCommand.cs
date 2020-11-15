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
            ValidationResult = new RegisterOrderCommandValidation().Validate(this);//注意：这个就是命令验证，我们会在下边实现它
            return ValidationResult.IsValid;
        }
    }
}