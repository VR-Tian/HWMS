using System;
using System.Collections.Generic;
using HWMS.DoMain.Core.Models;

namespace HWMS.DoMain.Models
{
    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order : Entity
    {
        public Order(Guid UserID)
        {
            this._OrderDate = DateTime.UtcNow;
        }

        public Order()
        {
            if (this.Id == Guid.Empty)
            {
                this.Id = Guid.NewGuid();
                this._OrderDate = DateTime.UtcNow;
                // this._OrderNumber
            }
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

    }
}
