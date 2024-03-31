using System.ComponentModel.DataAnnotations;

namespace Tabi.Model
{
    public class UserType
    {
        [Key]
        public int UserTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public required string Name { get; set; }

    }
}
