using System;

namespace HWMS.DoMain.Models
{
    public class OrderItem
    {   
        public Guid Id { get; set; }
        public Product Product { get; set; }
    }
}
