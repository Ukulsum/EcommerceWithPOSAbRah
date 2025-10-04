using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'purchase_product_return' table
    public class PurchaseProductReturn : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? ReturnId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public string ImeiNumber { get; set; } // text maps to string

        public double? Qty { get; set; } // Nullable for double

        public int? PurchaseUnitId { get; set; } // Nullable for int

        public double? NetUnitCost { get; set; } // Nullable for double

        public double? Discount { get; set; } // Nullable for double

        public double? TaxRate { get; set; } // Nullable for double

        public double? Tax { get; set; } // Nullable for double

        public double? Total { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'purchases' table
    public class Purchase : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        [StringLength(255)]
        public string MemoNo { get; set; }

        public int? UserId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? SupplierId { get; set; } // Nullable for int

        public int? CurrencyId { get; set; } // Nullable for int

        public double? ExchangeRate { get; set; } // Nullable for double

        public int? Item { get; set; } // Nullable for int

        public int? TotalQty { get; set; } // Nullable for int

        public double? TotalDiscount { get; set; } // Nullable for double

        public double? TotalTax { get; set; } // Nullable for double

        public double? TotalCost { get; set; } // Nullable for double

        public double? OrderTaxRate { get; set; } // Nullable for double

        public double? OrderTax { get; set; } // Nullable for double

        public double? OrderDiscount { get; set; } // Nullable for double

        public double? ShippingCost { get; set; } // Nullable for double

        public double? GrandTotal { get; set; } // Nullable for double

        public double? PaidAmount { get; set; } // Nullable for double

        public int? Status { get; set; } // Nullable for int

        public int? PaymentStatus { get; set; } // Nullable for int

        [StringLength(255)]
        public string Document { get; set; }

        public string Note { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'return_purchases' table
    public class ReturnPurchase : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? SupplierId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? UserId { get; set; } // Nullable for int

        public int? PurchaseId { get; set; } // Nullable for int

        public int? AccountId { get; set; } // Nullable for int

        public int? CurrencyId { get; set; } // Nullable for int

        public double? ExchangeRate { get; set; } // Nullable for double

        public int? Item { get; set; } // Nullable for int

        public double? TotalQty { get; set; } // Nullable for double

        public double? TotalDiscount { get; set; } // Nullable for double

        public double? TotalTax { get; set; } // Nullable for double

        public double? TotalCost { get; set; } // Nullable for double

        public double? OrderTaxRate { get; set; } // Nullable for double

        public double? OrderTax { get; set; } // Nullable for double

        public double? GrandTotal { get; set; } // Nullable for double

        [StringLength(255)]
        public string Document { get; set; }

        public string ReturnNote { get; set; } // text maps to string

        public string StaffNote { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }


    // Model for the 'returns' table
    public class Return : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? UserId { get; set; } // Nullable for int

        public int? SaleId { get; set; } // Nullable for int

        public int? CashRegisterId { get; set; } // Nullable for int

        public int? CustomerId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? BillerId { get; set; } // Nullable for int

        public int? AccountId { get; set; } // Nullable for int

        public int? CurrencyId { get; set; } // Nullable for int

        public double? ExchangeRate { get; set; } // Nullable for double

        public int? Item { get; set; } // Nullable for int

        public double? TotalQty { get; set; } // Nullable for double

        public double? TotalDiscount { get; set; } // Nullable for double

        public double? TotalTax { get; set; } // Nullable for double

        public double? TotalPrice { get; set; } // Nullable for double

        public double? OrderTaxRate { get; set; } // Nullable for double

        public double? OrderTax { get; set; } // Nullable for double

        public double? GrandTotal { get; set; } // Nullable for double

        [StringLength(255)]
        public string Document { get; set; }

        public string ReturnNote { get; set; } // text maps to string

        public string StaffNote { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
