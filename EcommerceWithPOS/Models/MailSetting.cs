using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'mail_settings' table
    public class MailSetting : BaseClass
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Driver { get; set; }

        [StringLength(255)]
        public string Host { get; set; }

        [StringLength(255)]
        public string Port { get; set; }

        [StringLength(255)]
        public string FromAddress { get; set; }

        [StringLength(255)]
        public string FromName { get; set; }

        [StringLength(255)]
        public string Username { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Encryption { get; set; }

        //public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
    }
}
