using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'faq_categories' table
    public class FaqCategory : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Order { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'faqs' table
    public class Faq : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Question { get; set; }

        public string Answer { get; set; } // text maps to string

        public int? CategoryId { get; set; } // Nullable for int

        [StringLength(255)]
        public string Order { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
