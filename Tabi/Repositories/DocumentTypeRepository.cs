using Microsoft.EntityFrameworkCore;
using Tabi.Context;
using Tabi.Model;

namespace Tabi.Repositories
{

    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetDocumentTypes();
        Task<DocumentType?> GetDocumentType(int id);
        Task<DocumentType> CreateDocumentType(DocumentType documentType);
        Task<DocumentType> UpdateDocumentType(DocumentType documentType);
        Task<DocumentType?> DeleteDocumentType(int id);

    }

    public class DocumentTypeRepository(TabiContext db) : IDocumentTypeRepository
    {
        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            return await db.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType?> GetDocumentType(int id)
        {
            return await db.DocumentTypes.FindAsync(id);
        }

        public async Task<DocumentType> CreateDocumentType(DocumentType documentType)
        {
            db.DocumentTypes.Add(documentType);
            await db.SaveChangesAsync();
            return documentType;
        }

        public async Task<DocumentType> UpdateDocumentType(DocumentType documentType)
        {
            db.Entry(documentType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return documentType;
        }

        public async Task<DocumentType?> DeleteDocumentType(int id)
        {
            DocumentType? documentType = await db.DocumentTypes.FindAsync(id);
            if (documentType == null) return documentType;
            documentType.IsActive = false;
            db.Entry(documentType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return documentType;
        }
    }

}