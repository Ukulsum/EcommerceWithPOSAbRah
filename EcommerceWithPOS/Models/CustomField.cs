using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Table: custom_fields
    public class CustomField : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string BelongsTo { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Type { get; set; } // Could be an enum if specific types are defined

        public string DefaultValue { get; set; } // SQL text maps to string

        public string OptionValue { get; set; } // SQL text maps to string

        public int? GridValue { get; set; } // Nullable for optional int

        public bool IsTable { get; set; } // tinyint(1) maps to bool
        public bool IsInvoice { get; set; }
        public bool IsRequired { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDisable { get; set; }

        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
    }
}
