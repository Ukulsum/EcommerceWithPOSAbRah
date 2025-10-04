using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'sliders' table
    public class Slider : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Image1 { get; set; }

        [StringLength(255)]
        public string Image2 { get; set; }

        [StringLength(255)]
        public string Image3 { get; set; }

        public int? Order { get; set; } // Nullable for int

        public int? Status { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
