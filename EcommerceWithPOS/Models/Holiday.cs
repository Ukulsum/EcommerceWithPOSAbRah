using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'holidays' table
    public class Holiday
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; } // Nullable for int

        public DateTime? FromDate { get; set; } // Nullable for date

        public DateTime? ToDate { get; set; } // Nullable for date

        public string Note { get; set; } // text maps to string

        public bool IsApproved { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
