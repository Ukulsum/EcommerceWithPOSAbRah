using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: customer_groups
    public class CustomerGroup : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Percentage { get; set; } // Stored as string, could be parsed to decimal if needed

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
