using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace pharaoh_moto_club.Models {
    [Table("members")]
    [Index(nameof(Email), IsUnique = true)]
    public class Member {
        [Key]
        [Column("member_id")]
        public int MemberId { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("nickname")]
        public required string Nickname { get; set; }
        
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        [Column("email")]
        public required string Email { get; set; }
        [JsonIgnore]
        [Column("password")]
        [Required]
        public string? Password { get; set; }
    }
}
