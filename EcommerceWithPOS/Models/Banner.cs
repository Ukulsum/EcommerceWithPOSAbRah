using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: banners
    public class Banner : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Link { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string? LogoImage { get; set; }

        public int Order { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int Status { get; set; } // int(11) for status, could be an enum if specific values are defined

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
