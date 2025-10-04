using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: sales
    public class Sale : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? UserId { get; set; }
        public int? CashRegisterId { get; set; }
        public int? TableId { get; set; }
        public int? Queue { get; set; }
        public int? CustomerId { get; set; }
        public int? WarehouseId { get; set; }
        public int? BillerId { get; set; }
        public int? Item { get; set; }
        public double TotalQty { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalTax { get; set; }
        public double TotalPrice { get; set; }
        public double GrandTotal { get; set; }
        public int? CurrencyId { get; set; }
        public double ExchangeRate { get; set; }
        public double OrderTaxRate { get; set; }
        public double OrderTax { get; set; }

        [StringLength(255)]
        public string OrderDiscountType { get; set; }

        public double OrderDiscountValue { get; set; }
        public double OrderDiscount { get; set; }
        public int? CouponId { get; set; }
        public double CouponDiscount { get; set; }
        public double ShippingCost { get; set; }
        public int SaleStatus { get; set; }
        public int PaymentStatus { get; set; }

        [StringLength(255)]
        public string Document { get; set; }

        public double PaidAmount { get; set; }

        [StringLength(255)]
        public string BillingName { get; set; }

        [StringLength(255)]
        public string BillingPhone { get; set; }

        [StringLength(255)]
        public string BillingEmail { get; set; }

        [StringLength(255)]
        public string BillingAddress { get; set; }

        [StringLength(255)]
        public string BillingCity { get; set; }

        [StringLength(255)]
        public string BillingState { get; set; }

        [StringLength(255)]
        public string BillingCountry { get; set; }

        [StringLength(255)]
        public string BillingZip { get; set; }

        [StringLength(255)]
        public string ShippingName { get; set; }

        [StringLength(255)]
        public string ShippingPhone { get; set; }

        [StringLength(255)]
        public string ShippingEmail { get; set; }

        [StringLength(255)]
        public string ShippingAddress { get; set; }

        [StringLength(255)]
        public string ShippingCity { get; set; }

        [StringLength(255)]
        public string ShippingState { get; set; }

        [StringLength(255)]
        public string ShippingCountry { get; set; }

        [StringLength(255)]
        public string ShippingZip { get; set; }

        [StringLength(255)]
        public string SaleType { get; set; } = "pos"; // Default value

        [StringLength(255)]
        public string PaymentMode { get; set; }

        public string SaleNote { get; set; } // text
        public string StaffNote { get; set; } // text

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }

        [ForeignKey("BillerId")]
        public Biller Biller { get; set; }

        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }
    }
}
