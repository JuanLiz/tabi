using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class Crop
    {
        [Key]
        public int CropID { get; set; }
        
        [Required]
        [ForeignKey(nameof(Lot))]
        public int LotID { get; set; }
        
        [Required]
        public float Hectares { get; set; }
        
        [Required]
        [ForeignKey(nameof(CropType))]
        public int CropTypeID { get; set; }
        
        [Required]
        [ForeignKey(nameof(CropStatus))]
        public int CropStatusID { get; set; }
        
        [Required]
        public DateOnly PlantingDate { get; set; }

        public DateOnly? HarvestDate { get; set; }


        public Lot Lot { get; set; } = null!;
        public CropType CropType { get; set; } = null!;
        public CropStatus CropStatus { get; set; } = null!;
    }
}
