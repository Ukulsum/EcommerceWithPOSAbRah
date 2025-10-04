using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'expense_categories' table
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }


    // Model for the 'expenses' table
    public class Expense : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? ExpenseCategoryId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public int? AccountId { get; set; } // Nullable for int

        public int? UserId { get; set; } // Nullable for int

        public int? CashRegisterId { get; set; } // Nullable for int

        public double Amount { get; set; }

        public string Note { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
