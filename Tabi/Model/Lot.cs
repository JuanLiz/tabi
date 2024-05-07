using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Tabi.Model
{
    public class Lot
    {
        [Key]
        public int LotID { get; set; }
        [ForeignKey(nameof(Farm))]
        [Sieve(CanFilter = true, CanSort = true)]
        public required int FarmID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        public required float Hectares { get; set; }
        [ForeignKey(nameof(SlopeType))]
        public required int SlopeTypeID { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual Farm? Farm { get; set; }
        public virtual SlopeType? SlopeType { get; set; }
    }
}
