using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: brands
    public class Brand 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        [ValidateNever]
        public string LogoPath{ get; set; }

        [NotMapped]
        [ValidateNever]
        public IFormFile Logo { get; set; }

        [DisplayName("Description")]
        public string ShortDescription { get; set; } // SQL text maps to string

        [StringLength(255)]
        public string Slug { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool
    }
}
