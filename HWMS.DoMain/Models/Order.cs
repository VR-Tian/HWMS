﻿using System;

namespace HWMS.DoMain.Models
{
    public class Order
    {
        public Order(Guid UserID)
        {
            this._OrderDate = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }

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

        public void PlaceOrder()
        {
            throw new NotImplementedException();
        }

    }
}
