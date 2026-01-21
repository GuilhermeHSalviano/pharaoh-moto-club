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
        [Required]
        [Column("nickname")]
        public required string Nickname { get; set; }
        [Required]
        [Column("cpf")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Seu cpf não está no formato correto!")]
        public required string Cpf { get; set; }
        [JsonIgnore]
        [Column("password")]
        public string Password { get; set; } = null!;
        [Required]
        [Column("city")]
        public required string City { get; set; }
        [Column("state")]
        public required string State { get; set; }
        [Column("states_visited")]
        public int StatesVisited { get; set; }
        [Column("entry_date")]
        public DateTime EntryDate { get; set; }
        [Column("triennium")]
        public int Triennium { get; set; }
        [Column("has_been_abroad")]
        public bool HasBeenAbroad { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column("is_first")]
        public bool IsFirst { get; set; } = false;
        [Column("wife_name")]
        public string? WifeName { get; set; }
        [Column("wife_nickname")]
        public string? WifeNickname { get; set; }
        [Column("coat_of_arms")]
        public bool CoatOfArms { get; set; }
        [Column("profile_photo")]
        public byte[]? ProfilePhoto { get; set; }
        [Column("motorcycle_sign")]
        public string? MotorcycleSign { get; set; }
        [Column("motorcycle_brand")]
        public string? MotorcycleBrand { get; set; }
        [Column("motorcycle_name")]
        public string? MotorcycleName { get; set; }
        [Column("motorcycle_nickname")]
        public string? MotorcycleNickName { get; set; }
        [Column("board_id")]
        public int? BoardId { get; set; }
        public Board? Board { get; set; }
    }
}
