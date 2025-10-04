using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'stock_counts' table
    public class StockCount : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? WarehouseId { get; set; } // Nullable for int

        [StringLength(255)]
        public string CategoryId { get; set; } // varchar(255) instead of int

        [StringLength(255)]
        public string BrandId { get; set; } // varchar(255) instead of int

        public int? UserId { get; set; } // Nullable for int

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string InitialFile { get; set; }

        [StringLength(255)]
        public string FinalFile { get; set; }

        public string Note { get; set; } // text maps to string

        public bool IsAdjusted { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
