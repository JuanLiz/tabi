using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class CropStatus
    {
        [Key]
        public int CropStatusID { get; set; }
        [MaxLength(20)]
        public required string Name { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
