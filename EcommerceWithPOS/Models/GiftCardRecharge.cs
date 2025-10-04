using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'gift_card_recharges' table
    public class GiftCardRecharge
    {
        [Key]
        public int Id { get; set; }

        public int? GiftCardId { get; set; } // Nullable for int

        public double Amount { get; set; }

        public int? UserId { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'gift_cards' table
    public class GiftCard : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string CardNo { get; set; }

        public double Amount { get; set; }

        public double Expense { get; set; }

        public int? CustomerId { get; set; } // Nullable for int

        public int? UserId { get; set; } // Nullable for int

        public DateTime? ExpiredDate { get; set; } // Nullable for date

        public int? CreatedBy { get; set; } // Nullable for int

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
