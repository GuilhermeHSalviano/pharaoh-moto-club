using pharaoh_moto_club.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Dtos {
    public class MemberDto {
        public required string Name { get; set; }
        public required string Nickname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
