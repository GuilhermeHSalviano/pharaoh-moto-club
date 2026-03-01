using Microsoft.AspNetCore.Mvc;
using My.Exceptions;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EventAttendant : ControllerBase {
        private readonly EventAttendantServices _eventAttendantServices;

        public EventAttendant(EventAttendantServices eventAttendantServices) {
            _eventAttendantServices = eventAttendantServices;
        }

        [HttpPost("{eventId}/{attendantId}")]
        public async Task<IActionResult> AttendEvent(int eventId, int attendantId) {
            try {
                await _eventAttendantServices.SaveAttendantOnDb(eventId, attendantId);
                return NoContent();
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            } catch(MemberNotAllowed error) {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("quit/{eventId}/{attendantId}")]
        public async Task<IActionResult> QuitEvent(int eventId, int attendantId) {
            try {
                await _eventAttendantServices.DeleteAttendantOnDb(eventId, attendantId);
                return NoContent();
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            } 
        }
    }
}
