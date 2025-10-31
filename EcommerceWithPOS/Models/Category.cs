using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: categories
    public class Category : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        [DisplayName("Category")]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [ValidateNever]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile? Images { get; set; }

        public int? ParentId { get; set; } // Foreign key to self (categories table for hierarchical structure)

        //[NotMapped]
        //public string ParentCategory {  get; set; }

        [StringLength(140)]
        public string? PageTitle { get; set; }

        public string? ShortDescription { get; set; } // SQL text maps to string

        [StringLength(150)]
        public string? Slug { get; set; }

        //[StringLength(255)]
        //public string? Icon { get; set; }

        public bool Featured { get; set; } // tinyint(4) as bool for simplicity
        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation property for self-referencing (optional)
        [ForeignKey("ParentId")]
        [ValidateNever]
        public Category Parent { get; set; }
    }


    public class ProductColor
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string Name { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        [ValidateNever]
        public Product Product { get; set; }

        public virtual ICollection<PSize> Sizes { get; set; }
    }
    public class PSize
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Size")]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(20)]
        [Display(Name = "Short Name")]
        public string? ShortName { get; set; }

        public int? Quantity { get; set; }

        [ForeignKey("Color")]
        public int? ProductColorId { get; set; }
        [ValidateNever]
        public ProductColor Color { get; set; }
    }

}
