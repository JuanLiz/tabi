using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class CropManagement
    {
        [Key]
        public int CropManagementID { get; set; }
        [ForeignKey(nameof(Crop))]
        public required int CropID { get; set; }
        [ForeignKey(nameof(CropManagementType))]
        public required int CropManagementTypeID { get; set; }
        public required DateOnly Date { get; set; }
        [MaxLength(int.MaxValue)]
        public required string Description { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual Crop? Crop { get; set; }
        public virtual CropManagementType? CropManagementType { get; set; }

    }
}
