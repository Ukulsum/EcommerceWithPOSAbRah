using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: couriers
    public class Courier : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string BaseUrl { get; set; }

        public string ApiConfig { get; set; } // longtext with JSON validation, maps to string

        public string Address { get; set; } // SQL text maps to string

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
