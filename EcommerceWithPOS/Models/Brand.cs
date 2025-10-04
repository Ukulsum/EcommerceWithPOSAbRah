using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: brands
    public class Brand : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string PageTitle { get; set; }

        public string ShortDescription { get; set; } // SQL text maps to string

        [StringLength(255)]
        public string Slug { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
