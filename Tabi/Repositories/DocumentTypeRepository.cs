using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetDocumentTypes();
        Task<DocumentType> GetDocumentType(int id);
        Task<DocumentType> PostDocumentType(DocumentType documentType);
        Task<DocumentType> PutDocumentType(int id, DocumentType documentType);
        Task<DocumentType> DeleteDocumentType(int id);

    }

    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly TabiContext _context;

        public DocumentTypeRepository(TabiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType> GetDocumentType(int id)
        {
            return await _context.DocumentTypes.FindAsync(id);
        }

        public async Task<DocumentType> PostDocumentType(DocumentType documentType)
        {
            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();
            return documentType;
        }

        public async Task<DocumentType> PutDocumentType(int id, DocumentType documentType)
        {
            _context.Entry(documentType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return documentType;
        }

        public async Task<DocumentType> DeleteDocumentType(int id)
        {
            var documentType = await _context.DocumentTypes.FindAsync(id);
            if (documentType == null)
            {
                return null;
            }

            _context.DocumentTypes.Remove(documentType);
            await _context.SaveChangesAsync();
            return documentType;
        }
    }
}
