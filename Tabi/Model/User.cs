using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Tabi.Model
{
    [Index(nameof(Username), IsUnique = false)]
    [Index(nameof(Email), IsUnique = false)]
    [Index(nameof(DocumentNumber), IsUnique = false)]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey(nameof(UserType))]
        public required int UserTypeID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(30)]
        public required string LastName { get; set; }
        [ForeignKey(nameof(DocumentType))]
        public int? DocumentTypeID { get; set; }
        [MaxLength(10)]
        public string? DocumentNumber { get; set; }
        [MaxLength(12)]
        public string? Username { get; set; }
        [MaxLength(320)]
        public required string Email { get; set; }
        [MinLength(6)]
        [MaxLength(128)]
        [JsonIgnore]
        public string Password { get; set; } = null!;
        [MaxLength(10)]
        public string? Phone { get; set; }
        [MaxLength(50)]
        public string? Address { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual UserType? UserType { get; set; }
        public virtual DocumentType? DocumentType { get; set; }
    }
}
