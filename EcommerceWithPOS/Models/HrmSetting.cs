using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'hrm_settings' table
    public class HrmSetting
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Checkin { get; set; }

        [StringLength(255)]
        public string Checkout { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
