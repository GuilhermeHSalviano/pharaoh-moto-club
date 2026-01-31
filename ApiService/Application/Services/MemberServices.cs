using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using pharaoh_moto_club.Models;

namespace Services {
    public class MemberServices {
        private readonly AppDbContext _context;

        public MemberServices(AppDbContext context) {
            _context = context;
        }

        public async Task InsertNewMemberOnDb(MemberDto model) {
            var doesMemberAlreadyExist = await _context.Members.FirstOrDefaultAsync(c => c.Cpf == model.Cpf) != null;
            if (doesMemberAlreadyExist) throw new EntityAlreadyExists("O membro já existe");
            Member newMember = MemberFactory.CreateMember(model);
            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();
        }

        public string GenerateJwtToken(Member model) {
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

        public async Task<Member> FindMemberById(int id) {
            var member =  await _context.Members.FindAsync(id);
            if(member == null) throw new EntityNotFound("O membro não foi encontrado");
            return member;
        }

        public bool IsPasswordValid(AuthenticationDto model, Member member) {
            return BCrypt.Net.BCrypt.Verify(model.Password, member.Password);
        }
    }
}