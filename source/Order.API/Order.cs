using System;

namespace Order.API
{
    public class Order
    {
        public DateTime OrderedDate { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public string AppUrl { get; set; }
    }
}
