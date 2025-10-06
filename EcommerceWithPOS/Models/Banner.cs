using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ValidateNever]
        public string BannerImagePath { get; set; }

        [NotMapped]
        [DisplayName("Image")]
        public IFormFile BannerImage { get; set; }

        [StringLength(255)]
        //[ValidateNever]
        public string? LogoImagePath { get; set; }

        [NotMapped]
        //[ValidateNever]
        [DisplayName("Logo")]
        public IFormFile? LogoImage { get; set; }

        public int Order { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int Status { get; set; } // int(11) for status, could be an enum if specific values are defined

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
