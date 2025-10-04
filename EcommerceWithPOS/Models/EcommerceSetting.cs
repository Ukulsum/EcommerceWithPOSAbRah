using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'ecommerce_settings' table
    public class EcommerceSetting : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string SiteTitle { get; set; }

        [StringLength(255)]
        public string Logo { get; set; }

        [StringLength(255)]
        public string Favicon { get; set; }

        [StringLength(255)]
        public string StorePhone { get; set; }

        [StringLength(255)]
        public string StoreEmail { get; set; }

        [StringLength(255)]
        public string StoreAddress { get; set; }

        public int? HomePage { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? BillerId { get; set; } // Nullable for int

        [StringLength(255)]
        public string ContactFormEmail { get; set; }

        public double? FreeShippingFrom { get; set; } // Nullable for double

        public double? FlatRateShipping { get; set; } // Nullable for double

        public string CheckoutPages { get; set; } // longtext maps to string (JSON)

        public byte GiftCard { get; set; } // tinyint(4) maps to byte

        [StringLength(255)]
        public string CustomCss { get; set; }

        public string Colors { get; set; } // longtext maps to string (JSON)

        [StringLength(255)]
        public string CustomJs { get; set; }

        [StringLength(255)]
        public string ChatCode { get; set; }

        [StringLength(255)]
        public string AnalyticsCode { get; set; }

        [StringLength(255)]
        public string FbPixelCode { get; set; }

        public int? SellWithoutStock { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        [StringLength(255)]
        public string HeaderScript { get; set; }

        [StringLength(255)]
        public string BodyScript { get; set; }

        [StringLength(255)]
        public string GtmCode { get; set; }

        public string StoreLocation { get; set; } // text maps to string
    }
}
