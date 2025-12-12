using System.ComponentModel.DataAnnotations;

namespace pharaoh_moto_club.Dtos
{
    public class AuthenticationDto
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}