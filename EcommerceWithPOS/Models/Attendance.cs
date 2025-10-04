using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: attendances
    public class Attendance : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } // SQL date maps to DateTime

        public int? EmployeeId { get; set; } // Foreign key to employees table
        public int? UserId { get; set; } // Foreign key to users table

        [StringLength(255)]
        public string Checkin { get; set; }

        [StringLength(255)]
        public string Checkout { get; set; }

        public int Status { get; set; } // int(11) for status, could be an enum if specific values are defined

        public string Note { get; set; } // SQL text maps to string

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        // Navigation properties (optional)
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
