using System.ComponentModel.DataAnnotations;

namespace pharaoh_moto_club.Dtos
{
    public class AuthenticationDto
    {
        public required int MemberId { get; set; }
        public required string Password { get; set; }
    }
}