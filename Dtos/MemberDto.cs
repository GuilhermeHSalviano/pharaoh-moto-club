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
    }
}
