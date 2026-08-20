using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Dtos;
using Microsoft.AspNetCore.Authorization;
using Services;
using My.Exceptions;
using pharaoh_moto_club.Factories;
using Utilities;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase {
        public MemberServices _memberServices;
        public IConfiguration _configuration;
    

        public MembersController( MemberServices memberServices, IConfiguration configuration) {
            _memberServices = memberServices;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMember(MemberDto model) {
            try {
                await _memberServices.InsertNewMemberOnDb(model);
                return NoContent();
            }
            catch (EntityAlreadyExists error) {
                return Conflict(error.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Authenticate(AuthenticationDto model) {
            try {
                var refreshTokenExpirationMinutes = _configuration["Token:RefreshTokenExpirationMinutes"];
                if(refreshTokenExpirationMinutes == null) return Problem("Define um tempo de expiração do refresh token em minutos");
                await _memberServices.CheckUserCredentials(model);
                var member = await _memberServices.FindMemberByEmail(model.Email);
                var accessToken = _memberServices.GenerateJwtToken(member);
                _memberServices.SendAccessTokenToHttpOnly(accessToken);
                var refreshTokenString = TokenUtilities.CreateRefreshTokenString();
                var refreshToken = RefreshTokenFactory.CreateRefreshTokenDto(member.MemberId, int.Parse(refreshTokenExpirationMinutes), refreshTokenString);
                _memberServices.SendRefreshTokenToHttpOnly(refreshTokenString);
                _memberServices.SaveRefreshToken(refreshToken);
                var claims = ClaimsFactory.CreateMemberClaims(member);
                return Ok(claims);
            }
            catch(MemberNotAllowed error) {
                return Unauthorized(new {message = error.Message});
            }
            catch(EntityNotFound error) {
                return Unauthorized(new {message = error.Message});
            }
            catch(BadRequest error) {
                return Unauthorized(new {message = error.Message});
            }
        }

        [AllowAnonymous]
        [HttpPost("refreshToken")]
        public async Task<ActionResult> RefreshToken() {
            try {
                var refreshTokenExpirationMinutes = _configuration["Token:RefreshTokenExpirationMinutes"];
                var oldAccessToken = Request.Cookies["accessToken"];
                var oldRefreshToken = Request.Cookies["refreshToken"];
                if(oldRefreshToken is null) throw new EntityNotFound("Não foi enviado nenhum refresh token");
                string hashToken = TokenUtilities.HashToken(oldRefreshToken);
                RefreshToken existingToken = _memberServices.CheckIfTokenExists(hashToken);
                if(existingToken is null)  return Unauthorized();
                if (!existingToken.IsActive) {
                    if(existingToken.RevokedAt is not null) {
                        await _memberServices.RevokeAllActiveTokensAsync(existingToken.MemberId);
                    }
                    return Unauthorized("O token já foi revogado");
                }

                await _memberServices.CheckIfUserExists(existingToken.MemberId);

                var newRefreshTokenString = TokenUtilities.CreateRefreshTokenString();
                if(refreshTokenExpirationMinutes == null) return Problem("Define um tempo de expiração do refresh token em minutos");
                var newRefreshTokenDto = RefreshTokenFactory
                    .CreateRefreshTokenDto(existingToken.MemberId, int.Parse(refreshTokenExpirationMinutes), newRefreshTokenString);
                
                await _memberServices.RevokeOldRefreshTokenAsync(newRefreshTokenString, existingToken.RefreshTokenId);
                var member = await _memberServices.FindMemberById(existingToken.MemberId);
                var newAccessToken = _memberServices.GenerateJwtToken(member);
                _memberServices.SendAccessTokenToHttpOnly(newAccessToken);
                _memberServices.SendRefreshTokenToHttpOnly(newRefreshTokenString);
                _memberServices.SaveRefreshToken(newRefreshTokenDto);

                return NoContent();
            }
            catch(EntityNotFound error) {
                return Unauthorized(new {message = error.Message});
            }
        }
    }
}

