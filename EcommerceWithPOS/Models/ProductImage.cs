using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceWithPOS.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public List<IFormFile> Image {  get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
