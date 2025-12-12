using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace pharaoh_moto_club.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberDto model)
        {
            var cpf = _context.Members.SingleAsync(b => b.Cpf == model.Cpf);
            if (cpf != null) return Conflict("Este membro já existe");
            Member newMember = new Member
            {
                Name = model.Name,
                Nickname = model.Nickname,
                Cpf = model.Cpf,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                City = model.City,
                State = model.State,
                StatesVisited = model.StatesVisited,
                EntryDate = model.EntryDate,
                Rank = model.Rank,
                Triennium = model.Triennium,
                HasBeenAbroad = model.HasBeenAbroad,
                BirthDate = model.BirthDate,
                IsFirst = model.IsFirst,
                WifeName = model.Wifename,
                WifeNickname = model.WifeNickname,
                CoatOfArms = model.CoatOfArms,
                OffBoarding = model.OffBoarding,
                ProfilePhoto = model.ProfilePhoto,
                MotorcycleSign = model.MotorcycleSign,
                MotorcycleBrand = model.MotorcycleBrand,
                MotorcycleName = model.MotorcycleName,
                MotorcycleNickName = model.MotorcycleNickName,
                IsActive = model.IsActive,
                IsSystemManager = model.IsSystemManager,
                BoardId = model.BoardId,
            };

            _context.Members.Add(newMember);

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{MemberId}/board/{BoardId}")]
        public async Task<IActionResult> AssignMemberToBoard(int memberId, int boardId)
        {
            var memberToBeAssigned = await _context.Members.FindAsync(memberId);
            if (memberToBeAssigned == null) return NotFound();
            memberToBeAssigned.BoardId = boardId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Authenticate(AuthenticationDto model)
        {
            var Member = await _context.Members.FindAsync(model.MemberId);
            if (Member == null || !BCrypt.Net.BCrypt.Verify(model.Password, Member.Password)) return Unauthorized();
            var jwt = GenerateJwtToken(Member);

            return Ok(new { jwtToken = jwt });
        }

        private string GenerateJwtToken(Member model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Ry74cBQva5dThwbwchR9jhbtRFnJxWSZ");
            var claims = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, model.MemberId.ToString()),
                new Claim("name", model.Name),
                new Claim("nickname", model.Nickname),
                new Claim(ClaimTypes.Role, model.Rank.ToString())
            ]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
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

