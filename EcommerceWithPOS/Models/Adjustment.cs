using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: adjustments
    public class Adjustment : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? WarehouseId { get; set; } // Nullable for optional FK

        [StringLength(255)]
        public string Document { get; set; }

        public double TotalQty { get; set; }
        public int? Item { get; set; } // Likely represents item count or a reference

        public string Note { get; set; } // SQL text maps to string

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation property (optional, for EF Core relationships)
        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
    }

    // Enum for acc_adjustments.type
    public enum AdjustmentType
    {
        Deposit,
        Withdrawal
    }
}
