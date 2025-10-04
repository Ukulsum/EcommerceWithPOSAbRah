using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'social_links' table
    public class SocialLink : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public string Icon { get; set; } // text maps to string

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        public int? Order { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
