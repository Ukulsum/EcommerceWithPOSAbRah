using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'dso_alerts' table
    public class DsoAlert : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public string ProductInfo { get; set; } // longtext maps to string

        public int NumberOfProducts { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
