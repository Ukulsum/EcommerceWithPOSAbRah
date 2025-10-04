using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: coupons
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Type { get; set; } // Could be an enum if specific types are defined

        public double Amount { get; set; }
        public double MinimumAmount { get; set; }
        public int Quantity { get; set; }
        public int Used { get; set; }

        public DateTime? ExpiredDate { get; set; } // SQL date, nullable for optional

        public int? UserId { get; set; } // Foreign key to users table

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation property (optional, for EF Core relationships)
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
