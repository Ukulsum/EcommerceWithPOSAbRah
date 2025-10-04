using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: products
    public class Product : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Slug { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string BarcodeSymbology { get; set; }

        public int? BrandId { get; set; } // Nullable for optional FK
        public int? CategoryId { get; set; }
        public int? UnitId { get; set; }
        public int? PurchaseUnitId { get; set; }
        public int? SaleUnitId { get; set; }

        public double Cost { get; set; }
        public double Price { get; set; }
        public double WholesalePrice { get; set; }
        public double Qty { get; set; }
        public double AlertQuantity { get; set; }
        public double DailySaleObjective { get; set; }

        public bool Promotion { get; set; } // tinyint(4) as bool for simplicity

        [StringLength(255)]
        public string PromotionPrice { get; set; }

        public DateTime? StartingDate { get; set; }
        public DateTime? LastDate { get; set; }

        public int? TaxId { get; set; }
        public int? TaxMethod { get; set; }

        public string Image { get; set; } // longtext maps to string
        public string File { get; set; } // varchar(255)

        public bool IsEmbeded { get; set; }
        public bool IsVariant { get; set; }
        public bool IsBatch { get; set; }
        public bool IsDiffPrice { get; set; }
        public bool IsImei { get; set; }
        public bool Featured { get; set; }
        public bool IsOnline { get; set; }
        public bool InStock { get; set; }
        public bool TrackInventory { get; set; }

        [StringLength(255)]
        public string ProductList { get; set; }

        [StringLength(255)]
        public string VariantList { get; set; }

        [StringLength(255)]
        public string QtyList { get; set; }

        [StringLength(255)]
        public string PriceList { get; set; }

        public string ProductDetails { get; set; } // text
        public string ShortDescription { get; set; } // text
        public string Specification { get; set; } // text

        [StringLength(255)]
        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; } // text
        public string RelatedProducts { get; set; } // longtext
        public string VariantOption { get; set; } // text
        public string VariantValue { get; set; } // text

        public bool IsActive { get; set; }

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties (optional)
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }


    // Model for the 'product_purchases' table
    public class ProductPurchase : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? PurchaseId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public string ImeiNumber { get; set; } // text maps to string

        public double? Qty { get; set; } // Nullable for double

        public double? Recieved { get; set; } // Nullable for double

        public int? PurchaseUnitId { get; set; } // Nullable for int

        public double? NetUnitCost { get; set; } // Nullable for double

        public double? Discount { get; set; } // Nullable for double

        public double? TaxRate { get; set; } // Nullable for double

        public double? Tax { get; set; } // Nullable for double

        public double? Total { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_quotation' table
    public class ProductQuotation : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? QuotationId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public double? Qty { get; set; } // Nullable for double

        public int? SaleUnitId { get; set; } // Nullable for int

        public double? NetUnitPrice { get; set; } // Nullable for double

        public double? Discount { get; set; } // Nullable for double

        public double? TaxRate { get; set; } // Nullable for double

        public double? Tax { get; set; } // Nullable for double

        public double? Total { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_returns' table
    public class ProductReturn : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? ReturnId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public string ImeiNumber { get; set; } // text maps to string

        public double? Qty { get; set; } // Nullable for double

        public int? SaleUnitId { get; set; } // Nullable for int

        public double? NetUnitPrice { get; set; } // Nullable for double

        public double? Discount { get; set; } // Nullable for double

        public double? TaxRate { get; set; } // Nullable for double

        public double? Tax { get; set; } // Nullable for double

        public double? Total { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_sales' table
    public class ProductSale : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? SaleId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public string ImeiNumber { get; set; } // text maps to string

        public double? Qty { get; set; } // Nullable for double

        public double? ReturnQty { get; set; } // Nullable for double

        public int? SaleUnitId { get; set; } // Nullable for int

        public double? NetUnitPrice { get; set; } // Nullable for double

        public double? Discount { get; set; } // Nullable for double

        public double? TaxRate { get; set; } // Nullable for double

        public double? Tax { get; set; } // Nullable for double

        public double? Total { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_transfer' table
    public class ProductTransfer : BaseClass 
    {
        [Key]
        public int Id { get; set; }

        public int? TransferId { get; set; } // Nullable for int

        public int? ProductId { get; set; } // Nullable for int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public string ImeiNumber { get; set; } // text maps to string

        public double? Qty { get; set; } // Nullable for double

        public int? PurchaseUnitId { get; set; } // Nullable for int

        public double? NetUnitCost { get; set; } // Nullable for double

        public double? TaxRate { get; set; } // Nullable for double

        public double? Tax { get; set; } // Nullable for double

        public double? Total { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }


    // Model for the 'product_variants' table
    public class ProductVariant : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? ProductId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public int? Position { get; set; } // Nullable for int

        [StringLength(255)]
        public string VariantName { get; set; }

        [StringLength(255)]
        public string ItemCode { get; set; }

        public double? AdditionalCost { get; set; } // Nullable for double

        public double? AdditionalPrice { get; set; } // Nullable for double

        public double? Qty { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'product_warehouse' table
    public class ProductWarehouse : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ProductId { get; set; } // varchar(255) instead of int

        public int? ProductBatchId { get; set; } // Nullable for int

        public int? VariantId { get; set; } // Nullable for int

        public string ImeiNumber { get; set; } // text maps to string

        public int? WarehouseId { get; set; } // Nullable for int

        public double? Qty { get; set; } // Nullable for double

        public double? Price { get; set; } // Nullable for double

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
