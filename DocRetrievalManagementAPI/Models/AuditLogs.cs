using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocRetrievalManagementAPI.Models
{
    public class AuditLogs
    {
        [Key]
        public Int64 Id { get; set; }

        [StringLength(450)]
        public string UserId { get; set; }

        [StringLength(100)]
        public string Action { get; set; }

        [StringLength(250)]
        public string TableName { get; set; }
        public Int64 EntityId { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
