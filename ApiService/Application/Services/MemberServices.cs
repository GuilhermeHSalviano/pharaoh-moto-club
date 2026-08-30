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

        public void SendRefreshTokenToHttpOnly(string refreshToken, DateTimeOffset expirationTime) {

            _httpContextAccessor?.HttpContext?.Response.Cookies.Append("refreshToken", refreshToken, 
                new CookieOptions {
                    Expires = expirationTime.AddSeconds(5),
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
                    Expires = accessTokenExpirationTime.AddSeconds(5),
                    HttpOnly = true,
                    //Secure = isProduction,
                    IsEssential = true,
                    //SameSite = SameSiteMode.None
                }
            );
        }

        public  void SaveRefreshToken(RefreshTokenDto refreshTokenDto) {
            RefreshToken newRefreshToken = RefreshTokenFactory.CreateRefreshToken(refreshTokenDto);
            _context.RefreshToken.Add(newRefreshToken);
            _context.SaveChanges();
        }

        public RefreshToken CheckIfTokenExists(string token) {
            var tokenHash = TokenUtilities.HashToken(token);
            var existingToken =  _context.RefreshToken.FirstOrDefault(tuple => tuple.RefreshTokenHash == tokenHash);
            if(existingToken is null) throw new EntityNotFound("O token não foi encontrado");
            return existingToken;
        }

        public async Task RevokeAllActiveTokensAsync(int memberId) {
            var refreshToken = _context.RefreshToken
                .Where(tuple => tuple.MemberId == memberId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.RevokedAt, DateTimeOffset.UtcNow)
                );
        }

        public async Task CheckIfUserExists(int memberId) {
            var member = _context.Members.FirstOrDefaultAsync(member => member.MemberId == memberId);
            if(member is null) throw new EntityNotFound("O usuário a que se refere o token não foi encontrado");
        }

        public async Task RevokeOldRefreshTokenAsync(string newRefreshTokenString, int oldRefreshTokenId) {
            var oldRefreshToken = await _context.RefreshToken.FirstOrDefaultAsync(refreshToken => refreshToken.RefreshTokenId == oldRefreshTokenId);
            if(oldRefreshToken is null) throw new EntityNotFound("Não foi encontrado o token");
            oldRefreshToken.ExpiresAt = DateTimeOffset.UtcNow;
            oldRefreshToken.ReplacedByToken = TokenUtilities.HashToken(newRefreshTokenString);
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