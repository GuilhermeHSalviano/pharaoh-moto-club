using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using pharaoh_moto_club.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Services;
using My.Exceptions;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase {
        private readonly AppDbContext _context;
        public MemberServices _memberServices;

        public MembersController(AppDbContext context, MemberServices memberServices) {
            _context = context;
            _memberServices = memberServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberDto model) {
            try {
                await _memberServices.InsertNewMemberOnDb(model);
                return NoContent();
            } catch (EntityAlreadyExists error) {
                return Conflict(error.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Authenticate(AuthenticationDto model) {
            var Member = await _context.Members.FindAsync(model.MemberId);
            if (Member == null || !BCrypt.Net.BCrypt.Verify(model.Password, Member.Password)) return Unauthorized();
            var jwt = GenerateJwtToken(Member);

            return Ok(new { jwtToken = jwt });
        }

        private string GenerateJwtToken(Member model) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Ry74cBQva5dThwbwchR9jhbtRFnJxWSZ");
            var claims = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, model.MemberId.ToString()),
                new Claim("name", model.Name),
                new Claim("nickname", model.Nickname),
            ]);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

