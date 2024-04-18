using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class Lot
    {
        [Key]
        public int LotID { get; set; }

        
        [ForeignKey(nameof(Farm))]
        public int FarmID { get; set; }

        
        [MaxLength(30)]
        public string Name { get; set; }

        
        public float Hectares { get; set; }

        
        [ForeignKey(nameof(SlopeType))]
        public int SlopeTypeID { get; set; }


        public Farm Farm { get; set; }
        public SlopeType SlopeType { get; set; }
    }
}
