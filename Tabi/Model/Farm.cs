using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class Farm
    {
        [Key]
        public int FarmID { get; set; }
        [ForeignKey(nameof(User))]
        public required int UserID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(50)]
        public string? Address { get; set; }
        public required float Hectares { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual User? User { get; set; }

    }
}
