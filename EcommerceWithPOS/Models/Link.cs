using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'links' table
    public class Link : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Label { get; set; }

        [StringLength(255)]
        public string LinkUrl { get; set; } // Named LinkUrl to avoid conflict with class name

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string WidgetTitle { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
