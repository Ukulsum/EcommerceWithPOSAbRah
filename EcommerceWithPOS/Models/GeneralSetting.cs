using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'general_settings' table
    public class GeneralSetting : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string SiteTitle { get; set; }

        [StringLength(255)]
        public string SiteLogo { get; set; }

        public bool IsRtl { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        [StringLength(255)]
        public string Currency { get; set; }

        public int? PackageId { get; set; } // Nullable for int

        [StringLength(255)]
        public string SubscriptionType { get; set; }

        [StringLength(255)]
        public string StaffAccess { get; set; }

        [StringLength(255)]
        public string WithoutStock { get; set; } = "no"; // Default value 'no'

        [StringLength(255)]
        public string DateFormat { get; set; }

        [StringLength(255)]
        public string DevelopedBy { get; set; }

        [StringLength(255)]
        public string InvoiceFormat { get; set; }

        public int Decimal { get; set; } = 2; // Default value 2

        public int? State { get; set; } // Nullable for int

        [StringLength(255)]
        public string Theme { get; set; }

        public string Modules { get; set; } // text maps to string

        [StringLength(255)]
        public string CurrencyPosition { get; set; }

        public DateTime? ExpiryDate { get; set; } // Nullable for date

        public bool IsZatca { get; set; } // tinyint(1) maps to bool

        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(255)]
        public string VatRegistrationNumber { get; set; }

        [StringLength(255)]
        public string MushakNo { get; set; }

        public bool SmsFeature { get; set; } // tinyint(1) maps to bool
    }
}
