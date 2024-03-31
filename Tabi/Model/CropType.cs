using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class CropType
    {
        [Key]
        public int CropTypeID { get; set; }

        [Required]
        [StringLength(30)]
        public required string Name { get; set; }

        [Required]
        public float ExpectedYield { get; set; }
    }
}
