using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: currencies
    public class Currency : BaseClass
    { 
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

        [StringLength(2)]
        public string Symbol { get; set; }

        public double ExchangeRate { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
