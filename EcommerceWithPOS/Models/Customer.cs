using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: customers
    public class Customer : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? CustomerGroupId { get; set; }
        public int? UserId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string TaxNo { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string State { get; set; }

        [StringLength(255)]
        public string PostalCode { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        public double Points { get; set; }
        public bool IsActive { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        public double Deposit { get; set; }
        public double Expense { get; set; }

        public string Wishlist { get; set; } // longtext
        public double PreviousDue { get; set; }
        public DateTime? DueBefore { get; set; }

        // Navigation properties
        [ForeignKey("CustomerGroupId")]
        public CustomerGroup CustomerGroup { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
