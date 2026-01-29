using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pharaoh_moto_club.Models {
    [Table("members")]
    public class Member {
        [Key]
        [Column("member_id")]
        public int MemberId { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("nickname")]
        public required string Nickname { get; set; }
        [Required]
        [Column("cpf")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Seu cpf não está no formato correto!")]
        public required string Cpf { get; set; }
        [JsonIgnore]
        [Column("password")]
        public required string Password { get; set; }
        [Column("coat_of_arms")]
        public bool CoatOfArms { get; set; } = false;
        [Column("is_member_active")]
        public bool IsmemberActive {get; set;} = true;
    }
}
