using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class Harvest
    {
        [Key]
        public int HarvestID { get; set; }

        [Required]
        [ForeignKey(nameof(Crop))]
        public int CropID { get; set; }

        [Required]
        [ForeignKey(nameof(HarvestStatus))]
        public int HarvestStatusID { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [Required]
        public float Amount { get; set; }


        public Crop Crop { get; set; } = null!;
        public HarvestStatus HarvestStatus { get; set; } = null!;


    }
}
