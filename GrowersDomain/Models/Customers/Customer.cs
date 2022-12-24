using GrowersDomain.Models.SystemUser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GrowersDomain.Models.Customers
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer Name is Required")]
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        [ForeignKey("SystemUserId")]
        public SystemUser.SystemUser SystemUsers { get; set; }
        [Required(ErrorMessage = "User is Required")]
        public int SystemUserId { get; set; }
    }
}
