using System.ComponentModel.DataAnnotations;

namespace EcommerceWithPOS.Models
{
    // Model for the 'failed_jobs' table
    public class FailedJob
    {
        [Key]
        public int Id { get; set; }

        public string Connection { get; set; } // text maps to string

        public string Queue { get; set; } // text maps to string

        public string Payload { get; set; } // longtext maps to string

        public string Exception { get; set; } // longtext maps to string

        public DateTime FailedAt { get; set; } // timestamp with default current_timestamp
    }
}
