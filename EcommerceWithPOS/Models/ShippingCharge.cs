using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Model for the 'shipping_charges' table
    public class ShippingCharge : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Value { get; set; } // decimal(8,2) maps to decimal

        public bool Status { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
