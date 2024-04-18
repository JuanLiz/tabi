using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class SlopeType
    {
        [Key]
        public int SlopeTypeID { get; set; }

        
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}
