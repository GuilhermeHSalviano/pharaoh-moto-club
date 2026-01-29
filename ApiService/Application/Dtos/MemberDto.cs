using pharaoh_moto_club.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Dtos {
    public class MemberDto {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public required string Cpf { get; set; }
        public required string Password { get; set; }
        public bool CoatOfArms { get; set; }
        public bool IsMemberActive { get; set; } = true;
    }
}
