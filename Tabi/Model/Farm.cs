using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class Farm
    {
        [Key]
        public int FarmID { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;

        [Required]
        public float Hectares { get; set; }


        public User User { get; set; } = null!;

    }
}
