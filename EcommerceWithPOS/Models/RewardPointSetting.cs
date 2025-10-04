using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'reward_point_settings' table
    public class RewardPointSetting : BaseClass
    {
        [Key]
        public int Id { get; set; }

        public double? PerPointAmount { get; set; } // Nullable for double

        public double? MinimumAmount { get; set; } // Nullable for double

        public int? Duration { get; set; } // Nullable for int

        [StringLength(255)]
        public string Type { get; set; }

        public bool IsActive { get; set; } // tinyint(1) maps to bool

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
