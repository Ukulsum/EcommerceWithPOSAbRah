using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: deliveries
    public class Delivery : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? SaleId { get; set; } // Foreign key to sales table
        public int? UserId { get; set; } // Foreign key to users table
        public int? CourierId { get; set; } // Foreign key to couriers table

        public string Address { get; set; } // SQL text maps to string

        [StringLength(255)]
        public string DeliveredBy { get; set; }

        [StringLength(255)]
        public string ReceivedBy { get; set; }

        [StringLength(255)]
        public string File { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        [StringLength(255)]
        public string Status { get; set; } // Could be an enum if specific values are defined

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        [StringLength(255)]
        public string ConsignmentId { get; set; }

        [StringLength(255)]
        public string Invoice { get; set; }

        [StringLength(255)]
        public string TrackingCode { get; set; }

        [StringLength(255)]
        public string RecipientName { get; set; }

        [StringLength(255)]
        public string RecipientPhone { get; set; }

        [StringLength(255)]
        public string CodAmount { get; set; } // Stored as varchar, could be parsed to decimal if needed

        // Navigation properties (optional, for EF Core relationships)
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CourierId")]
        public Courier Courier { get; set; }
    }
}
