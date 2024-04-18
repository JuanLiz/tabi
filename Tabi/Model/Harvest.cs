using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class Harvest
    {
        [Key]
        public int HarvestID { get; set; }
        [ForeignKey(nameof(Crop))]
        public required int CropID { get; set; }
        [ForeignKey(nameof(HarvestState))]
        public required int HarvestStateID { get; set; }
        public required DateOnly Date { get; set; }
        public required float Amount { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

        public virtual Crop? Crop { get; set; }
        public virtual HarvestState? HarvestState { get; set; }


    }
}
