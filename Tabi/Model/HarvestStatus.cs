using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class HarvestStatus
    {
        [Key]
        public int HarvestStatusID { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }
    }
}
