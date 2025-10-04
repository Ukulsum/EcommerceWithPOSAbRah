using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'users' table
    public class User : BaseClass
    {

        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(100)]
        public string RememberToken { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string CompanyName { get; set; }

        public int? RoleId { get; set; } // Nullable for int

        public int? BillerId { get; set; } // Nullable for int

        public int? WarehouseId { get; set; } // Nullable for int

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        public bool IsDeleted { get; set; } // tinyint(1) maps to bool
    }

    // Model for the 'user_activity_logs' table
    public class UserActivityLog : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; } // Nullable for int, unsigned

        [StringLength(255)]
        public string Action { get; set; }

        public string Description { get; set; } // text maps to string

        [StringLength(255)]
        public string IpAddress { get; set; }

        [StringLength(255)]
        public string Browser { get; set; }

        [StringLength(255)]
        public string Os { get; set; }

        [StringLength(255)]
        public string Device { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'variants' table
    public class Variant : BaseClass 
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'warehouses' table
    public class Warehouse : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public string Address { get; set; } // text maps to string

        [StringLength(255)]
        public string DefaultAccount { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'webhook_settings' table
    public class WebhookSetting : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Token { get; set; }

        public bool Status { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }

    // Model for the 'widgets' table
    public class Widget : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string Order { get; set; }

        [StringLength(255)]
        public string FeatureTitle { get; set; }

        [StringLength(255)]
        public string FeatureSecondaryTitle { get; set; }

        [StringLength(255)]
        public string FeatureIcon { get; set; }

        [StringLength(255)]
        public string SiteInfoName { get; set; }

        [StringLength(255)]
        public string SiteInfoDescription { get; set; }

        [StringLength(255)]
        public string SiteInfoAddress { get; set; }

        [StringLength(255)]
        public string SiteInfoPhone { get; set; }

        [StringLength(255)]
        public string SiteInfoEmail { get; set; }

        [StringLength(255)]
        public string SiteInfoHours { get; set; }

        [StringLength(255)]
        public string NewsletterTitle { get; set; }

        [StringLength(255)]
        public string NewsletterText { get; set; }

        [StringLength(255)]
        public string QuickLinksTitle { get; set; }

        [StringLength(255)]
        public string QuickLinksMenu { get; set; }

        [StringLength(255)]
        public string TextTitle { get; set; }

        [StringLength(255)]
        public string TextContent { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
