using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase {
        private readonly EventServices _eventServices;

        public EventsController(EventServices eventServices) {
            _eventServices = eventServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent(EventDto model) {
            try {
                await _eventServices.SaveEventOnDb(model);
                return NoContent();
            } catch(MemberNotAllowed error) {
                return Conflict(error.Message);
            }
        }
    }

}