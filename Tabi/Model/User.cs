using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tabi.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [ForeignKey(nameof(UserType))]
        public int UserTypeID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(30)]
        public string LastName { get; set; } = null!;

        [ForeignKey(nameof(DocumentType))]
        public int? DocumentTypeID { get; set; }

        public string? Document { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 18 characters")]
        public string Password { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string? Phone { get; set; }
        public string? Address { get; set; }


        public UserType UserType { get; set; } = null!;
        public DocumentType DocumentType { get; set; } = null!;
    }
}
