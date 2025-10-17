using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EcommerceWithPOS.Models
{
    // Table: products

    public class Product : BaseClass
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [StringLength(150)]
        public string? Slug { get; set; }

        [StringLength(255)]
        [DisplayName("Product Code / Barcode")]
        public string? Code { get; set; }

        [StringLength(150)]
        public string Sku { get; set; } = null!;
        //stock keeping unit,Sku Example 1: ABC-12345-S-BL (Brand: ABC, Product ID: 12345, Size: Small, Color: Blue)

        [StringLength(255)]
        public string? Tags { get; set; }

        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Specification { get; set; }
        //public string? ProductDetails { get; set; }

        [NotMapped]
        [ValidateNever]
        public List<IFormFile> ProductPicture { get; set; }

        public string? PicturePath { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("Unit")]
        public int? UnitId { get; set; }

        [ForeignKey("Brand")]
        public int? BrandId { get; set; }

        [ForeignKey("Tax")]
        public int? TaxId { get; set; }

        // ----- Price & Stock -----
        [DisplayName("Product Cost")]
        public float PurchasePrice { get; set; }

        [DisplayName("Product Price")]
        public float RetailPrice { get; set; }

        [DisplayName("Wholesale Price")]
        public float WholeSalePrice { get; set; }
        public float Quantity { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmount { get; set; }

        public bool? IsActive { get; set; } = true;
        public bool? IsVariant { get; set; }
        [ForeignKey("Color")]
        public int ColorId { get; set; }
        [ForeignKey("Size")]
        public int SizeId { get; set; }
        [ValidateNever]
        public Color? Color { get; set; }
        [ValidateNever]
        public PSize? Size { get; set; }

        // ----- Navigation Properties -----
        [ValidateNever]
        public Category? Category { get; set; }

        [ValidateNever]
        public Unit? Unit { get; set; }

        [ValidateNever]
        public Brand? Brand { get; set; }

        [ValidateNever]
        public Tax? Tax { get; set; }

        [JsonIgnore]
        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }

        [NotMapped]
        [DisplayName("Final Price After Discount")]
        public float FinalPrice => RetailPrice - (float)(DiscountAmount ?? 0);

        [DisplayName("Tax Method")]
        public TaxMethod TaxMethod { get; set; } = TaxMethod.Exclusive;

        // ===== Custom SKU Generator =====
        public void GenerateSku()
        {
            string brandCode = Brand?.Name != null ? Brand.Name[..Math.Min(3, Brand.Name.Length)].ToUpper() : "GEN";
            string colorCode = Color?.Name != null ? Color.Name[..Math.Min(2, Color.Name.Length)].ToUpper() : "NA";
            string sizeCode = Size?.Name != null ? Size.Name[..1].ToUpper() : "F";
            string productCode = (Id > 0 ? Id.ToString("D5") : new Random().Next(10000, 99999).ToString());

            Sku = $"{brandCode}-{productCode}-{ sizeCode}-{ colorCode}";
        }
    }

    public enum TaxMethod
    {
        Exclusive, // Tax added on top of price
        Inclusive  // Tax included in price
    }

    //public class Product : BaseClass
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    [StringLength(150)]
    //    [DisplayName("Product Name")]
    //    public string ProductName { get; set; }

    //    //[StringLength(255)]
    //    //public string Slug { get; set; }

    //    [StringLength(150)]
    //    public string sku { get; set; }

    //    [StringLength(255)]
    //    public string? Tags { get; set; } //ata keno

    //    [StringLength(100)]
    //    [DisplayName("Product Code")]
    //    public string ProductCode { get; set; }

    //    [StringLength(150)]
    //    [DisplayName("Product Type")]
    //    public string ProductType { get; set; } // ata kno.ata ki lagbe

    //    [StringLength(150)]
    //    [DisplayName("Barcode Symbology")]
    //    public string BarcodeSymbology { get; set; }  //ata keno

    //    public int? BrandId { get; set; } // Nullable for optional FK
    //    public int? CategoryId { get; set; } // Nullable for optional FK

    //    [ForeignKey("Unit")]
    //    public int? UnitId { get; set; }
    //    public int? PurchaseUnitId { get; set; }  //ata kno ..
    //    public int? SaleUnitId { get; set; }  ///ata kno

    //    public double Cost { get; set; } //Buying Price
    //    public double Price { get; set; } //Selling Price

    //    [DisplayName("Wholesale Price")]
    //    public double WholesalePrice { get; set; }

    //    [DisplayName("Quantity")]
    //    public double Qty { get; set; }
    //    public double AlertQuantity { get; set; }  //ata kno
    //    public double DailySaleObjective { get; set; }  //ata kno

    //    public bool Promotion { get; set; } // tinyint(4) as bool for simplicity  // ata kno

    //    [StringLength(255)]
    //    public string PromotionPrice { get; set; }   //ata kno

    //    [DisplayName("Starting Date")]
    //    public DateTime? StartingDate { get; set; }

    //    [DisplayName("End Date")]
    //    public DateTime? LastDate { get; set; }

    //    [ForeignKey("Tax")]
    //    public int? TaxId { get; set; }
    //    public int? TaxMethod { get; set; }

    //    public string Image { get; set; } // longtext maps to string
    //    public string File { get; set; } // varchar(255)

    //    public bool IsEmbeded { get; set; }  // ata kno
    //    public bool IsVariant { get; set; }
    //    public bool IsBatch { get; set; }  //ata kno
    //    public bool IsDiffPrice { get; set; }  // ata kno
    //    public bool IsImei { get; set; }  //ata kno
    //    public bool Featured { get; set; }  //ata kno
    //    public bool IsOnline { get; set; }  //ata kno
    //    public bool InStock { get; set; }  //ata kno 
    //    public bool TrackInventory { get; set; }  //ata kno

    //    [StringLength(255)]
    //    public string ProductList { get; set; }  //ata kno 

    //    [StringLength(255)]
    //    public string VariantList { get; set; }  // ata kno

    //    [StringLength(255)]
    //    public string QtyList { get; set; }  //ata kno

    //    [StringLength(255)]
    //    public string PriceList { get; set; }

    //    public string ProductDetails { get; set; } // text
    //    public string ShortDescription { get; set; } // text
    //    public string Specification { get; set; } // text

    //    [StringLength(255)]
    //    public string MetaTitle { get; set; }

    //    public string MetaDescription { get; set; } // text  //ata kno
    //    public string RelatedProducts { get; set; } // longtext   //ata kno
    //    public string VariantOption { get; set; } // text    //ata kno 
    //    public string VariantValue { get; set; } // text   //ata kno

    //    public bool IsActive { get; set; }

    //    //public DateTime CreatedAt { get; set; }
    //    //public DateTime UpdatedAt { get; set; }

    //    // Navigation properties (optional)
    //    [ForeignKey("BrandId")]
    //    [ValidateNever]
    //    public Brand Brand { get; set; }

    //    [ForeignKey("CategoryId")]
    //    [ValidateNever]
    //    public Category Category { get; set; }

    //    [ValidateNever]
    //    public Unit Unit { get; set; }

    //    [ValidateNever]
    //    public Tax Tax { get; set; }
    //}


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
