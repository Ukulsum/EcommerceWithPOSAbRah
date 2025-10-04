using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'tables' table
    public class Table : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public int? NumberOfPerson { get; set; } // Nullable for int

        public string Description { get; set; } // text maps to string

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }


    // Model for the 'taxes' table
    public class Tax : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public double? Rate { get; set; } // Nullable for double

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'transfers' table
    public class Transfer : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string ReferenceNo { get; set; }

        public int? UserId { get; set; } // Nullable for int

        public int? Status { get; set; } // Nullable for int

        public int? FromWarehouseId { get; set; } // Nullable for int

        public int? ToWarehouseId { get; set; } // Nullable for int

        public int? Item { get; set; } // Nullable for int

        public double? TotalQty { get; set; } // Nullable for double

        public double? TotalTax { get; set; } // Nullable for double

        public double? TotalCost { get; set; } // Nullable for double

        public double? ShippingCost { get; set; } // Nullable for double

        public double? GrandTotal { get; set; } // Nullable for double

        [StringLength(255)]
        public string Document { get; set; }

        public string Note { get; set; } // text maps to string

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
