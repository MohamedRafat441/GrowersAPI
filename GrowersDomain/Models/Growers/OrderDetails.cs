using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GrowersDomain.Models.Growers
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("OrderId")]
        public Order Orders { get; set; }
        [Required(ErrorMessage = "Order is Required")]
        public int OrderId { get; set; }
        [ForeignKey("ProductId")]
        public Product Products { get; set; }
        [Required(ErrorMessage = "Product is Required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Order Number is Required")]
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        
    }
}
