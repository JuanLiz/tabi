using Tabi.Model;
using Tabi.Repositories;

namespace Tabi.Services
{

    public interface IDocumentTypeService
    {
        Task<IEnumerable<DocumentType>> GetDocumentTypes();
        Task<DocumentType?> GetDocumentType(int id);
        Task<DocumentType> CreateDocumentType(string Name);
        Task<DocumentType> UpdateDocumentType(int DocumentTypeID, string? Name);
        Task<DocumentType?> DeleteDocumentType(int id);

    }

    public class DocumentTypeService(IDocumentTypeRepository documentTypeRepository) : IDocumentTypeService
    {
        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            return await documentTypeRepository.GetDocumentTypes();
        }

        public async Task<DocumentType?> GetDocumentType(int id)
        {
            return await documentTypeRepository.GetDocumentType(id);
        }

        public async Task<DocumentType> CreateDocumentType(string Name)
        {
            DocumentType documentType = new() { Name = Name };
            return await documentTypeRepository.CreateDocumentType(documentType);
        }

        public async Task<DocumentType> UpdateDocumentType(int DocumentTypeID, string? Name)
        {
            DocumentType? documentType = await documentTypeRepository.GetDocumentType(DocumentTypeID);
            if (documentType == null) throw new Exception("DocumentType not found");
            documentType.Name = Name ?? documentType.Name;
            return await documentTypeRepository.UpdateDocumentType(documentType);
        }

        public async Task<DocumentType?> DeleteDocumentType(int id)
        {
            return await documentTypeRepository.DeleteDocumentType(id);
        }
    }
}
