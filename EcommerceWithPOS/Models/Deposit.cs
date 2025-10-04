using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: deposits
    public class Deposit : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public double Amount { get; set; }

        public int? CustomerId { get; set; } // Foreign key to customers table
        public int? UserId { get; set; } // Foreign key to users table

        public string Note { get; set; } // SQL text maps to string

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties (optional, for EF Core relationships)
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
