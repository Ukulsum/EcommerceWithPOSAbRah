using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'money_transfers' table
    public class MoneyTransfer : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? FromAccountId { get; set; } // Nullable for int

        public int? ToAccountId { get; set; } // Nullable for int

        public double Amount { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
