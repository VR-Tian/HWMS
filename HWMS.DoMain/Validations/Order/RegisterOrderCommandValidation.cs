using System;
using FluentValidation;
using HWMS.DoMain.Commands.Order;

namespace HWMS.DoMain.Validations.Order
{
    public class RegisterOrderCommandValidation : OrderValidation<RegisterOrderCommand>
    {
        public RegisterOrderCommandValidation()
        {
             ValidateOrderNumber();
        }
    }
}