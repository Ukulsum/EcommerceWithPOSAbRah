using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: cash_registers
    public class CashRegister : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public double CashInHand { get; set; }

        public int? UserId { get; set; } // Foreign key to users table
        public int? WarehouseId { get; set; } // Foreign key to warehouses table

        public bool Status { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties (optional, for EF Core relationships)
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("WarehouseId")]
        public Warehouse Warehouse { get; set; }
    }
}
