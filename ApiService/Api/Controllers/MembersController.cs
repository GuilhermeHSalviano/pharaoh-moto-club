using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Dtos;
using Microsoft.AspNetCore.Authorization;
using Services;
using My.Exceptions;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase {
        public MemberServices _memberServices;

        public MembersController( MemberServices memberServices) {
            _memberServices = memberServices;
        }

        [HttpPost]
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
                await _memberServices.CheckUserCredentials(model);
                var member = await _memberServices.FindMemberByEmail(model.Email);
                var claims = _memberServices.GenerateJwtToken(member);
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

