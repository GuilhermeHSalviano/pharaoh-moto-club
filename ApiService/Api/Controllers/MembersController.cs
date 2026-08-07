using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Dtos;
using Microsoft.AspNetCore.Authorization;
using Services;
using My.Exceptions;
using pharaoh_moto_club.Factories;

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
                var refreshToken = RefreshTokenFactory.CreateRefreshToken(member.MemberId, int.Parse(refreshTokenExpirationMinutes));
                _memberServices.SendRefreshTokenToHttpOnly(refreshToken);
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
    }
}

