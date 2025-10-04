using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'newsletter' table
    public class Newsletter : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
