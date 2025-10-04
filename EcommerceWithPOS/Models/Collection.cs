using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: collections
    public class Collection : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string PageTitle { get; set; }

        public string ShortDescription { get; set; } // SQL text maps to string

        [StringLength(255)]
        public string Slug { get; set; }

        public string Products { get; set; } // longtext maps to string, likely stores JSON or serialized data

        public bool Status { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
