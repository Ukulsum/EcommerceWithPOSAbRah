using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'product_adjustments' table
    public class ProductAdjustment : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? AdjustmentId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public double? UnitCost { get; set; } // Nullable for double

        public double? Qty { get; set; } // Nullable for double

        [StringLength(255)]
        public string Action { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_batches' table
    public class ProductBatch : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? ProductId { get; set; } // Nullable for int

        [StringLength(255)]
        public string BatchNo { get; set; }

        public DateTime? ExpiredDate { get; set; } // Nullable for date

        public double? Qty { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_imeis' table
    public class ProductImei : BaseClass 
    {
        [Key]
        public int Id { get; set; }

        public int? ProductId { get; set; } // Nullable for int, unsigned

        [StringLength(255)]
        public string Imei { get; set; }

        public int? IsSold { get; set; } // Nullable for int, unsigned

        public int? PurchaseId { get; set; } // Nullable for int, unsigned

        public int? SaleId { get; set; } // Nullable for int, unsigned

        public int? PurchaseReturnId { get; set; } // Nullable for int, unsigned

        public int? SaleReturnId { get; set; } // Nullable for int, unsigned

        public int? AdjustmentId { get; set; } // Nullable for int, unsigned

        public int? DamageId { get; set; } // Nullable for int, unsigned

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }


}
