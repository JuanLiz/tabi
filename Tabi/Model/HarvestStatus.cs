using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class HarvestStatus
    {
        [Key]
        public int HarvestStatusID { get; set; }

        
        [MaxLength(20)]
        public required string Name { get; set; }
    }
}
