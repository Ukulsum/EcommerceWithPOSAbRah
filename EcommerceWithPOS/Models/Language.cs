using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'languages' table
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
