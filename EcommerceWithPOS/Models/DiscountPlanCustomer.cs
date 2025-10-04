using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: discount_plan_customers
    public class DiscountPlanCustomer : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? DiscountPlanId { get; set; } // Foreign key to discount_plans table
        public int? CustomerId { get; set; } // Foreign key to customers table

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties (optional, for EF Core relationships)
        [ForeignKey("DiscountPlanId")]
        public DiscountPlan DiscountPlan { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
