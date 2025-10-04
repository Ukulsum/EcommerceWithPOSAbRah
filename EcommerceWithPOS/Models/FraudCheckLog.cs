using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'fraud_check_logs' table
    public class FraudCheckLog : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string PhoneNumber { get; set; }

        public string Response { get; set; } // longtext with JSON validation maps to string

        public DateTime? LastCheck { get; set; } // Nullable for date

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'fraud_checks' table
    public class FraudCheck
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ApiKey { get; set; }

        [StringLength(255)]
        public string BaseUrl { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

}
