using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'pages' table
    public class Page : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string PageName { get; set; }

        public string Description { get; set; } // longtext maps to string

        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(255)]
        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; } // text maps to string

        [StringLength(255)]
        public string OgTitle { get; set; }

        [StringLength(255)]
        public string OgImage { get; set; }

        public string OgDescription { get; set; } // text maps to string

        [StringLength(255)]
        public string Template { get; set; }

        public int? Status { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
