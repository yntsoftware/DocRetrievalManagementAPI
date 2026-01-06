using DocRetrievalManagementAPI.Data;
using DocRetrievalManagementAPI.Models;

namespace DocRetrievalManagementAPI.Services
{
    public interface IAuditLogService 
    {
        Task SaveAuditAsync(AuditLogs model,long EntityId);
    }
    public class AuditLogService: IAuditLogService
    {
        private readonly ApplicationDbContext _context;
        public AuditLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveAuditAsync(AuditLogs model , long EntityId) 
        {
            var audit = new AuditLogs
            {
                Action = model.Action,
                TableName = model.TableName,
                EntityId = EntityId,
                UserId = model.UserId,
                Timestamp = DateTime.Now
            };

            _context.AuditLogs.Add(audit);
            await _context.SaveChangesAsync();
        }

    }
}
