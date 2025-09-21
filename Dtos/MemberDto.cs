using pharaoh_moto_club.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Dtos {
    public class MemberDto {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string NickName { get; set; }
        [Required]
        public required string Cpf { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string City { get; set; }
        [Required]
        public required string State { get; set; }
        public int StatesVisited { get; set; }
        public DateTime EntryDate { get; set; }
        public Rank? Rank { get; set; }
        public int Triennium { get; set; }
        public bool HasBeenAbroad { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsFirst { get; set; } = false;
        public string? WifeName { get; set; }
        public string? WifeNickName { get; set; }
        public bool CoatOfArms { get; set; }
        public bool OffBoarding { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string? MotorCycleSign { get; set; }
        public string? MotorCycleBrand { get; set; }
        public string? MotorCycleName { get; set; }
        public string? MotorCycleNickName { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsSystemManager { get; set; } = false;
        public int? BoardId { get; set; }
    }
}
