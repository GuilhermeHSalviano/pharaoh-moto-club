using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using pharaoh_moto_club.Models;

namespace Services {
    public class MemberServices {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MemberServices(AppDbContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InsertNewMemberOnDb(MemberDto model) {
            var doesMemberAlreadyExist = await _context.Members.FirstOrDefaultAsync(c => c.Email == model.Email) != null;
            if (doesMemberAlreadyExist) throw new EntityAlreadyExists("O membro já existe");
            Member newMember = MemberFactory.CreateMember(model);
            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();
        }

        public MemberClaimsDto GenerateJwtToken(Member model) {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["ApiKey"]!);
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
            var encrypterToken = tokenHandler.WriteToken(token);

            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("token", encrypterToken, 
                new CookieOptions {
                    Expires = DateTime.Now.AddDays(7),
                    HttpOnly = true,
                    Secure = true,
                    IsEssential = true,
                    SameSite = SameSiteMode.None
                }
            );
            return new MemberClaimsDto {
                MemberId = model.MemberId,
                Nickname = model.Nickname,
                Name = model.Name
            };
        }

        public async Task<Member> FindMemberById(int id) {
            var member =  await _context.Members.FindAsync(id);
            if(member == null) throw new EntityNotFound("O membro não foi encontrado");
            return member;
        }

        public async Task<Member> FindMemberByEmail(string email) {
            var member =  await _context.Members.FirstOrDefaultAsync(c => c.Email == email);
            if(member == null) throw new EntityNotFound("O membro não foi encontrado");
            return member;
        }

        public async Task CheckUserCredentials(AuthenticationDto model) {
            var member = await _context.Members.FirstOrDefaultAsync(c => c.Email == model.Email);
            if(member == null) throw new EntityNotFound("Usuário ou senha incorretos!");
            if (!BCrypt.Net.BCrypt.Verify(model.Password, member.Password)) throw new MemberNotAllowed("Usuário ou senha incorretos!");
        }
    }
}