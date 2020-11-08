using System;
using System.Linq;
using HWMS.DoMain.Interfaces;
using HWMS.DoMain.Models;
using HWMS.Infrastructure.Contexts;

namespace HWMS.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext OrderContext) : base(OrderContext)
        {
        }
    }
}