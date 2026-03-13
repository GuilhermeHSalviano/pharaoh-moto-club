using Entities;
using Microsoft.AspNetCore.Mvc;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase {
        private readonly EventServices _eventServices;
        private readonly EditEvent _editEvent;

        public EventsController(EventServices eventServices, EditEvent editEvent) {
            _eventServices = eventServices;
            _editEvent = editEvent;
        }

        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetEventById(int eventId) {
            try {
                var Event = await _eventServices.GetEventByIdFromDb(eventId);
                return Ok(Event);
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent(EventDto model) {
            try {
                await _eventServices.SaveEventOnDb(model);
                return NoContent();
            }
            catch (MemberNotAllowed error) {
                return Conflict(error.Message);
            }
        }

        [HttpPut("edit/{eventId}/{authorId}")]
        public async Task<IActionResult> EditEvent(int eventId, EventDto model, int authorId) {
            try {
                await _editEvent.EditEventById(eventId, model, authorId);
                return NoContent();
            }
            catch (MemberNotAllowed error) {
                return Conflict(error.Message);
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            }
        }

        [HttpGet("states")]
        public List<StateAndItsCities> GetAllFutureEventStates() {
            return _eventServices.GetAllFutureEventStatesFromDb();
        }


        [HttpGet("city/{city}")]
        public IActionResult GetAllFutureEventsByCity(int city) {
            try {
                var events = _eventServices.GetAllFutureEventsByCityFromDb(city);
                return Ok(events);
            } catch(EntityNotFound error) {
                return NotFound(error.Message);
            }
            
        }
    }

}