using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Model for the 'lead_notes' table
    public class LeadNote : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? LeadId { get; set; } // Nullable for int

        public int? AddedBy { get; set; } // Nullable for int

        public string Notes { get; set; } // text maps to string

        [StringLength(255)]
        public string ActionDate { get; set; }

        public int? UpdatedBy { get; set; } // Nullable for int

        public int? StatusId { get; set; } // Nullable due to ON DELETE SET NULL

        [ForeignKey("StatusId")]
        public LeadStatus Status { get; set; } // Navigation property

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'lead_sources' table
    public class LeadSource : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; } // UNIQUE constraint

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        public int? Order { get; set; } // Nullable for int

        [StringLength(255)]
        public string Icon { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'lead_statuses' table
    public class LeadStatus : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; } // UNIQUE constraint

        [StringLength(255)]
        public string Color { get; set; } = "#000000"; // Default value '#000000'

        public int? Progress { get; set; } // Nullable for int

        [StringLength(255)]
        public string Icon { get; set; }

        public int? Order { get; set; } // Nullable for int

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'lead_subjects' table
    public class LeadSubject : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; } // UNIQUE constraint

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }


    // Model for the 'leads' table
    public class Lead : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Company { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Subject { get; set; }

        [StringLength(255)]
        public string NextActionDate { get; set; }

        public int? SourceId { get; set; } // Nullable due to ON DELETE SET NULL

        [ForeignKey("SourceId")]
        public LeadSource Source { get; set; } // Navigation property

        public int? StatusId { get; set; } // Nullable due to ON DELETE SET NULL

        [ForeignKey("StatusId")]
        public LeadStatus Status { get; set; } // Navigation property

        public string Description { get; set; } // text maps to string

        public int? AddedBy { get; set; } // Nullable for int

        public int? LeadManager { get; set; } // Nullable for int

        public int? AssignedTo { get; set; } // Nullable for int

        public int? LastUpdatedBy { get; set; } // Nullable for int

        public bool IsSold { get; set; } // tinyint(1) maps to bool

        public bool IsFailed { get; set; } // tinyint(1) maps to bool

        public int? CustomerId { get; set; } // Nullable for int

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        public int? SubjectId { get; set; } // Nullable due to ON DELETE SET NULL

        [ForeignKey("SubjectId")]
        public LeadSubject SubjectNavigation { get; set; } // Navigation property (named to avoid conflict with Subject property)
    }


}
