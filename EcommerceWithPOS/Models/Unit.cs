using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'units' table
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string UnitCode { get; set; }

        [StringLength(255)]
        public string UnitName { get; set; }
    }
}
