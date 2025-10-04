using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: discount_plan_discounts
    public class DiscountPlanDiscount : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? DiscountId { get; set; } // Foreign key to discounts table
        public int? DiscountPlanId { get; set; } // Foreign key to discount_plans table

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties (optional, for EF Core relationships)
        [ForeignKey("DiscountId")]
        public Discount Discount { get; set; }

        [ForeignKey("DiscountPlanId")]
        public DiscountPlan DiscountPlan { get; set; }
    }

    // Table: discount_plans
    public class DiscountPlan : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'discounts' table
    public class Discount : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string ApplicableFor { get; set; }

        public string ProductList { get; set; } // longtext maps to string

        public DateTime? ValidFrom { get; set; } // Nullable for date

        public DateTime? ValidTill { get; set; } // Nullable for date

        [StringLength(255)]
        public string Type { get; set; }

        public double Value { get; set; }

        public double? MinimumQty { get; set; } // Nullable for double

        public double? MaximumQty { get; set; } // Nullable for double

        [StringLength(255)]
        public string Days { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
