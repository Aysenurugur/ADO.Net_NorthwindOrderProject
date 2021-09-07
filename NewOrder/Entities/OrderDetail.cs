using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOrder.Entities
{
    class OrderDetail
    {
        public string CustomerID { get; set; }
        public string CustomerCompanyName { get; set; }
        public string ContactTitle { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
    }
}
