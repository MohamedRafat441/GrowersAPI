using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowersDomain.Models.Growers
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is Required")]
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public decimal Price { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public int CategoryId { get; set; }
        [ForeignKey("GrowerId")]
        public Grower Grower { get; set; }
        [Required(ErrorMessage = "Grower is Required")]
        public int GrowerId { get; set; }
    }
}
