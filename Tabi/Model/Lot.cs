using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class Lot
    {
        [Key]
        public int LotID { get; set; }

        [Required]
        [ForeignKey(nameof(Farm))]
        public int FarmID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        public float Hectares { get; set; }

        [Required]
        [ForeignKey(nameof(SlopeType))]
        public int SlopeTypeID { get; set; }


        public Farm Farm { get; set; } = null!;
        public SlopeType SlopeType { get; set; } = null!;
    }
}
