using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class CropType
    {
        [Key]
        public int CropTypeID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        public float ExpectedYield { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
