using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using pharaoh_moto_club.Models;
using Utilities;

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

        public string GenerateJwtToken(Member model) {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.UTF8.GetBytes(_configuration["ApiKey"]!);
            var claims = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, model.MemberId.ToString()),
                new Claim("name", model.Name),
                new Claim("nickname", model.Nickname),
            ]);
            var accessTokenMinutes = _configuration["Token:AccessTokenExpirationMinutes"];
            if (accessTokenMinutes == null) throw new Exception("Defina a duração do access token");

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(accessTokenMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void SendRefreshTokenToHttpOnly(string refreshToken) {

            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken, 
                new CookieOptions {
                    Expires = DateTimeOffset.UtcNow,
                    HttpOnly = true,
                    //Secure = isProduction,
                    IsEssential = true,
                    //SameSite = SameSiteMode.None
                }
            );
        }

        public void SendAccessTokenToHttpOnly(string accessToken ) {
            var accessTokenMinutes = _configuration["Token:AccessTokenExpirationMinutes"];
            DateTimeOffset accessTokenExpirationTime;
            if (accessTokenMinutes == null) throw new Exception("Defina a duração do access token");
            accessTokenExpirationTime = DateTimeOffset.UtcNow.AddMinutes(int.Parse(accessTokenMinutes));

            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("accessToken", accessToken, 
                new CookieOptions {
                    Expires = accessTokenExpirationTime,
                    HttpOnly = true,
                    //Secure = isProduction,
                    IsEssential = true,
                    //SameSite = SameSiteMode.None
                }
            );
        }

        public  void SaveRefreshToken(RefreshToken refreshToken) {
            _context.RefreshToken.Add(refreshToken);
             _context.SaveChanges();
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