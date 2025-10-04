using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'payrolls' table
    public class Payroll : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? EmployeeId { get; set; } // Nullable for int

        public int? AccountId { get; set; } // Nullable for int

        public int? UserId { get; set; } // Nullable for int

        [StringLength(255)]
        public string SalaryYear { get; set; }

        [StringLength(255)]
        public string SalaryMonth { get; set; }

        public double Amount { get; set; }

        [StringLength(255)]
        public string PayingMethod { get; set; }

        public string Note { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
