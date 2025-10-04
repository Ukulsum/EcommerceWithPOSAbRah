using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EcommerceWithPOS.Models
{
    // Model for the 'role_has_permissions' table
    public class RoleHasPermission
    {
        [Key]
        [Column(Order = 1)]
        public int PermissionId { get; set; } // Composite key, unsigned

        [Key]
        [Column(Order = 2)]
        public int RoleId { get; set; } // Composite key, unsigned

        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; } // Navigation property

        [ForeignKey("RoleId")]
        public Role Role { get; set; } // Navigation property
    }

    // Model for the 'roles' table
    public class Role : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; } // text maps to string

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }

        [StringLength(255)]
        public string GuardName { get; set; }
    }
}
