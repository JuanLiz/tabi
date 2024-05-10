using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tabi.Helpers;
using Tabi.Model;
using Tabi.Services;

namespace Tabi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController(IDocumentTypeService documentTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDocumentTypes()
        {
            IEnumerable<DocumentType> documentTypes = await documentTypeService.GetDocumentTypes();
            return Ok(documentTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDocumentType(int id)
        {
            DocumentType? documentType = await documentTypeService.GetDocumentType(id);
            if (documentType == null) return NotFound();
            return Ok(documentType);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateDocumentType(
            [FromForm][Required][MaxLength(30)] string Name)
        {
            DocumentType documentType = await documentTypeService.CreateDocumentType(Name);
            return CreatedAtAction(nameof(GetDocumentType), new { id = documentType.DocumentTypeID }, documentType);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateDocumentType(    
            [FromForm][Required] int DocumentTypeID,
            [FromForm][MaxLength(30)] string? Name)
        {
            DocumentType? documentType = await documentTypeService.GetDocumentType(DocumentTypeID);
            if (documentType == null) return NotFound();
            documentType = await documentTypeService.UpdateDocumentType(DocumentTypeID, Name);
            return Ok(documentType);
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            DocumentType? documentType = await documentTypeService.GetDocumentType(id);
            if (documentType == null) return NotFound();
            await documentTypeService.DeleteDocumentType(id);
            return NoContent();
        }
    }
}
