using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: default_couriers
    public class DefaultCourier : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        //[Index(IsUnique = true)] // Unique constraint for consignment_id
        public string ConsignmentId { get; set; }

        [StringLength(255)]
        //[Index] // Index for invoice
        public string Invoice { get; set; }

        [StringLength(255)]
        //[Index(IsUnique = true)] // Unique constraint for tracking_code
        public string TrackingCode { get; set; }

        [StringLength(255)]
        public string RecipientName { get; set; }

        [StringLength(255)]
        public string RecipientPhone { get; set; }

        public string RecipientAddress { get; set; } // SQL text maps to string

        [Column(TypeName = "decimal(10,2)")]
        public decimal CodAmount { get; set; }

        [Required]
        public CourierStatus Status { get; set; } // Enum for status, defaults to InReview

        public string Note { get; set; } // SQL text maps to string

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }


    // Enum for default_couriers.status
    public enum CourierStatus
    {
        InReview,
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }
}
