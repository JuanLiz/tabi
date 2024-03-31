using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class CropStatus
    {
        [Key]
        public int CropStatusID { get; set; }
        
        [Required]
        [StringLength(20)]
        public required string Name { get; set; }
    }
}
