using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: collections
    public class Collection : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [DisplayName("Collection Name")]
        public string CollectionName { get; set; }

        [StringLength(255)]
        public string? Image { get; set; }

        [StringLength(255)]
        public string? PageTitle { get; set; }

        public string ShortDescription { get; set; } // SQL text maps to string

        [StringLength(255)]
        public string? Slug { get; set; }
        //[ForeignKey("Products")]
        //public int? productId { get; set; }
        //[ValidateNever]
        public ICollection<Product> Products { get; set; }

        //public List<int> ProductId { get; set; } = new List<int>();

       /* public string Products { get; set; }*/ // longtext maps to string, likely stores JSON or serialized data

        public bool? Status { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
