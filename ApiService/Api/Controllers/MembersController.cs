using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
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
                var member = await _memberServices.FindMemberById(model.MemberId);
                if (!_memberServices.IsPasswordValid(model, member)) return Unauthorized();
                var jwt = _memberServices.GenerateJwtToken(member);
                return Ok(new { jwtToken = jwt });
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            }
        }
    }
}

