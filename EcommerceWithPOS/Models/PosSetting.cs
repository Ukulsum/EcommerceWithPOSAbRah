using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'pos_setting' table
    public class PosSetting : BaseClass
    {
        [Key]
        public int Id { get; set; } // UNIQUE constraint

        public int? CustomerId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? BillerId { get; set; } // Nullable for int

        public int? ProductNumber { get; set; } // Nullable for int

        public bool KeybordActive { get; set; } // tinyint(1) maps to bool

        public bool IsTable { get; set; } // tinyint(1) maps to bool

        [StringLength(255)]
        public string StripePublicKey { get; set; }

        [StringLength(255)]
        public string StripeSecretKey { get; set; }

        [StringLength(255)]
        public string PaypalLiveApiUsername { get; set; }

        [StringLength(255)]
        public string PaypalLiveApiPassword { get; set; }

        [StringLength(255)]
        public string PaypalLiveApiSecret { get; set; }

        public string PaymentOptions { get; set; } // text maps to string

        [StringLength(10)]
        public string InvoiceOption { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        public string Tnc { get; set; } // text maps to string

        [StringLength(255)]
        public string CourierInvoice { get; set; } = "regular-a5"; // enum maps to string with default
    }
}
