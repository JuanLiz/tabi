using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

    }
}
