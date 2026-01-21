using pharaoh_moto_club.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Dtos
{
    public class MemberDto
    {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public required string Cpf { get; set; }
        public required string Password { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public int StatesVisited { get; set; }
        public DateTime EntryDate { get; set; }
        public int Triennium { get; set; }
        public bool HasBeenAbroad { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsFirst { get; set; } = false;
        public string? Wifename { get; set; }
        public string? WifeNickname { get; set; }
        public bool CoatOfArms { get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string? MotorcycleSign { get; set; }
        public string? MotorcycleBrand { get; set; }
        public string? MotorcycleName { get; set; }
        public string? MotorcycleNickName { get; set; }
        public int? BoardId { get; set; }
    }
}
