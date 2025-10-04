using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: categories
    public class Category : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public int? ParentId { get; set; } // Foreign key to self (categories table for hierarchical structure)

        [StringLength(255)]
        public string PageTitle { get; set; }

        public string ShortDescription { get; set; } // SQL text maps to string

        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(255)]
        public string Icon { get; set; }

        public bool Featured { get; set; } // tinyint(4) as bool for simplicity
        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation property for self-referencing (optional)
        [ForeignKey("ParentId")]
        public Category Parent { get; set; }
    }

}
