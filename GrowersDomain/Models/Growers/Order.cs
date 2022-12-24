using GrowersDomain.Models.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GrowersDomain.Models.Growers
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Order Number is Required")]
        public Guid OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Customer is Required")]
        public int CustomerId { get; set; }
        [ForeignKey("GrowerId")]
        public Grower Grower { get; set; }
        [Required(ErrorMessage = "Grower is Required")]
        public int GrowerId { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
    }
}
