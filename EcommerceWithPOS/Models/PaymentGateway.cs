using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'payment_gateways' table
    public class PaymentGateway : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Config { get; set; } // longtext with JSON validation maps to string

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'payment_with_cheque' table
    public class PaymentWithCheque : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? PaymentId { get; set; } // Nullable for int

        [StringLength(255)]
        public string ChequeNo { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'payment_with_credit_card' table
    public class PaymentWithCreditCard : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? PaymentId { get; set; } // Nullable for int

        public int? CustomerId { get; set; } // Nullable for int

        [StringLength(255)]
        public string CustomerStripeId { get; set; }

        [StringLength(255)]
        public string ChargeId { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'payment_with_gift_card' table
    public class PaymentWithGiftCard : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? PaymentId { get; set; } // Nullable for int

        public int? GiftCardId { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'payment_with_PaymentGetway' table
    public class PaymentWithPaymentGateway : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? PaymentId { get; set; } // Nullable for int

        [StringLength(255)]
        public string TransactionId { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'payments' table
    public class Payment : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? PurchaseId { get; set; } // Nullable for int

        public int? SaleId { get; set; } // Nullable for int

        public int? CashRegisterId { get; set; } // Nullable for int

        public int? AccountId { get; set; } // Nullable for int

        [StringLength(255)]
        public string PaymentReference { get; set; }

        public int? UserId { get; set; } // Nullable for int

        //looptijd double Amount { get; set; }

        public double? UsedPoints { get; set; } // Nullable for double

        public double? Change { get; set; } // Nullable for double

        [StringLength(255)]
        public string PayingMethod { get; set; }

        public string PaymentNote { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        public int? SupplierId { get; set; } // Nullable for int, unsigned

        public int? CustomerId { get; set; } // Nullable for int, unsigned
    }
}
