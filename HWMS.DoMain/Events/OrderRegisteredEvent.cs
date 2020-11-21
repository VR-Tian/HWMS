using System;
using HWMS.DoMain.Core.Events;

namespace HWMS.DoMain.Events
{
    public class OrderRegisteredEvent : Event
    {
        public OrderRegisteredEvent(Guid Id, string oddNumber)
        {
            this.Id = Id;
            this.OrderNumber = oddNumber;
        }

        public Guid Id { get; set; }
        public string OrderNumber { get; private set; }
    }
}