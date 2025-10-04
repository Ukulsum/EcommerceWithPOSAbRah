using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'units' table
    public class Unit : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string UnitCode { get; set; }

        [StringLength(255)]
        public string UnitName { get; set; }

        public int? BaseUnit { get; set; } // Nullable for int

        [StringLength(255)]
        public string Operator { get; set; }

        public double? OperationValue { get; set; } // Nullable for double

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
