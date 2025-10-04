using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'quotations' table
    public class Quotation : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? UserId { get; set; } // Nullable for int

        public int? BillerId { get; set; } // Nullable for int

        public int? SupplierId { get; set; } // Nullable for int

        public int? CustomerId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? Item { get; set; } // Nullable for int

        public double? TotalQty { get; set; } // Nullable for double

        public double? TotalDiscount { get; set; } // Nullable for double

        public double? TotalTax { get; set; } // Nullable for double

        public double? TotalPrice { get; set; } // Nullable for double

        public double? OrderTaxRate { get; set; } // Nullable for double

        public double? OrderTax { get; set; } // Nullable for double

        public double? OrderDiscount { get; set; } // Nullable for double

        public double? ShippingCost { get; set; } // Nullable for double

        public double? GrandTotal { get; set; } // Nullable for double

        public int? QuotationStatus { get; set; } // Nullable for int

        [StringLength(255)]
        public string Document { get; set; }

        public string Note { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
