using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: accounts
    public class Account : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string AccountNo { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public double InitialBalance { get; set; }
        public double TotalBalance { get; set; }

        public string Note { get; set; } // SQL text maps to string

        public bool IsDefault { get; set; } // tinyint(1) maps to bool
        public bool IsActive { get; set; }

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }

    // Table: acc_adjustments
    public class AccountAdjustment : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; } // Foreign key to users table
        public int AccountId { get; set; } // Foreign key to accounts table

        [Required]
        public AdjustmentType Type { get; set; } // Enum for deposit/withdrawal

        public double Amount { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        

        // Navigation properties (optional, for EF Core relationships)
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}

