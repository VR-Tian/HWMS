using System;
using System.Collections.Generic;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models
{
    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order : Entity<int>
    {
        public Guid OrderID { get; }
        public Order(Guid orderID, string ordernumber, DateTime createDate)
        {
            this._OrderDate = createDate;
            this.OrderID = orderID;
            this.OrderNumber = ordernumber;
        }

        public Order()
        {
            // if (this.Id == Guid.Empty)
            // {
            //     this.Id = Guid.NewGuid();
            //     this._OrderDate = DateTime.UtcNow;
            //     // this._OrderNumber
            // }
        }

        private string _OrderNumber;
        public string OrderNumber
        {
            get { return _OrderNumber; }
            private set { _OrderNumber = value; }
        }

        private DateTime _OrderDate;
        public DateTime OrderDate
        {
            get { return _OrderDate; }
            private set { _OrderDate = value; }
        }

        public Address Address { get; private set; }

        public OrderStatus Status { get; set; }

    }

    public enum OrderStatus:int
    {
        创建=0,
        提交=1
    }
}
