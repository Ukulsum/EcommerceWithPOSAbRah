using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'permissions' table
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string GuardName { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
