using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'notifications' table
    public class Notification
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } // char(36) maps to string for UUID

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string NotifiableType { get; set; }

        public int NotifiableId { get; set; } // unsigned int maps to int

        public string Data { get; set; } // text maps to string

        public DateTime? ReadAt { get; set; } // Nullable for timestamp

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
