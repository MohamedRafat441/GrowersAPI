using GrowersDomain.Models.Growers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowersAPI.Models
{
    public class OrderModel
    {
        public List<OrderDetails> OrderDetails { get; set; }
        public int CustomerId { get; set; }
        public int GrowerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
