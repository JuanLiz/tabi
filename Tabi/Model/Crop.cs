using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class Crop
    {
        [Key]
        public int CropID { get; set; }
        [ForeignKey(nameof(Lot))]
        public required int LotID { get; set; }
        public required float Hectares { get; set; }
        [ForeignKey(nameof(CropType))]
        public required int CropTypeID { get; set; }
        [ForeignKey(nameof(CropState))]
        public required int CropStateID { get; set; }
        public required DateOnly PlantingDate { get; set; }
        public DateOnly? HarvestDate { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual Lot? Lot { get; set; }
        public virtual CropType? CropType { get; set; }
        public virtual CropState? CropState { get; set; }
    }
}
