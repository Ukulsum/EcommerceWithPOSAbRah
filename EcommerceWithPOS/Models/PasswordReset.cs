using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'password_resets' table
    public class PasswordReset
    {
        [Key]
        [StringLength(255)]
        public string Email { get; set; } // Key index, not a traditional PK

        [StringLength(255)]
        public string Token { get; set; }

        public DateTime? CreatedAt { get; set; } // Nullable for timestamp
    }
}
