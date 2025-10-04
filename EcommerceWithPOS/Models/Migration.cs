using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'migrations' table
    public class Migration
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string MigrationName { get; set; } // Named MigrationName to avoid conflict with class name

        public int Batch { get; set; }
    }
}
