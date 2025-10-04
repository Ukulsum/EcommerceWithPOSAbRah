using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'sms_configs' table
    public class SmsConfig : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public string SmsConfiguration { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'sms_gateways' table
    public class SmsGateway : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ApiUrl { get; set; }

        [StringLength(255)]
        public string GetBalanceApi { get; set; }

        public string Credentials { get; set; } // longtext with JSON validation maps to string

        public bool IsDefault { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'sms_templates' table
    public class SmsTemplate : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Template { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
