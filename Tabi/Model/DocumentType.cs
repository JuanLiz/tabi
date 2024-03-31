using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }
    }
}
