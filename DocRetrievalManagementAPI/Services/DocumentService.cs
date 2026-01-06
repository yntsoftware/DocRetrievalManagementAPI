using DocRetrievalManagementAPI.Data;
using DocRetrievalManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DocRetrievalManagementAPI.Services
{
    public interface IDocumentService
    {
        Task<Response> CreateAsync(DocModel model, AuditLogs audit);
        Task<Response> UpdateAsync(int id, DocModel model, AuditLogs audit);
        Task<List<Documents>> GetDocumentAll(string? category);
        Task<Documents> GetDocumentById(int id);
        Task<Response> DeleteAsync(int id, AuditLogs audit);
    }
    public class DocumentService: IDocumentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuditLogService _audit;
        public DocumentService(ApplicationDbContext context, IAuditLogService audit) { 
            _context = context;
            _audit = audit;
        }

        public async Task<Response> CreateAsync(DocModel model, AuditLogs audit) { 
            
            var _response = new Response();
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var doc = new Documents
                {
                    Title = model.Title,
                    Category = model.Category,
                    IsActive = true,
                    UploadedAt = DateTime.Now,
                    UploadedBy = audit.UserId,
                };

                _context.Documents.Add(doc);
                await _context.SaveChangesAsync();
                await _audit.SaveAuditAsync(audit , doc.Id);

                transaction.Commit();
                _response.Result = true;
                _response.Documents = doc;
            }
            catch
            {
                transaction.Rollback();
                _response.Result = false;
                _response.Documents = null;
            }

            return _response;
        }
        public async Task<Response> UpdateAsync(int id , DocModel model, AuditLogs audit) {
            var _response = new Response();
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var doc = await GetDocumentById(id);
                if (doc != null)
                {
                    doc.Title = model.Title;
                    doc.Category = model.Category;

                    await _context.SaveChangesAsync();
                    await _audit.SaveAuditAsync(audit, doc.Id);

                    transaction.Commit();
                    _response.Result = true;
                    _response.Documents = doc;
                }
                else {
                    _response.Result = false;
                    _response.Documents = doc;
                }
            }
            catch
            {
                transaction.Rollback();
                _response.Result = false;
                _response.Documents = null;
            }

            return _response;

        }
       
        public async Task<List<Documents>> GetDocumentAll(string? category)
        {
            var query = _context.Documents.Where(x => x.IsActive == true).AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(d => d.Category.ToLower() == category.ToLower());
            }

            return await query.ToListAsync();
        }

        public async Task<Documents> GetDocumentById(int id) {
            var doc = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            if (doc == null) return null;

            return doc;
        }

        public async Task<Response> DeleteAsync(int id, AuditLogs audit)
        {
            var _response = new Response();
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var doc = await GetDocumentById(id);
                if (doc != null)
                {
                    doc.IsActive = false;

                    await _context.SaveChangesAsync();
                    await _audit.SaveAuditAsync(audit, doc.Id);

                    transaction.Commit();
                    _response.Result = true;
                    _response.Documents = doc;
                }
                else
                {
                    _response.Result = false;
                    _response.Documents = doc;
                }
            }
            catch
            {
                transaction.Rollback();
                _response.Result = false;
                _response.Documents = null;
            }

            return _response;
        }
    }
}
