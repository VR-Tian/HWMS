using System;
using FluentValidation.Results;
using MediatR;

namespace HWMS.DoMain.Core.Commands
{
    public abstract class Command : IRequest
    {
        //时间戳
        public DateTime Timestamp { get; private set; }
        //验证结果，需要引用FluentValidation
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        //定义抽象方法，是否有效
        public abstract bool IsValid();
    }
}