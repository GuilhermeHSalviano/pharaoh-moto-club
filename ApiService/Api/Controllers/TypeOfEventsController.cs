using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
using Services;

namespace Cotrollers {
    [Route("[controller]")]
    [ApiController]
    public class TypeOfEventsController : ControllerBase {
        private readonly TypeOfEventServices _typeOfEventServices;

        public TypeOfEventsController(TypeOfEventServices typeOfEventServices) {
            _typeOfEventServices = typeOfEventServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTypeOfEvent(TypeOfEventDto model) {
            try {
                await _typeOfEventServices.SaveNewTypeOfEventOnDb(model);
                return NoContent();
            }
            catch (MemberNotAllowed error) {
                return Conflict(error.Message);
            } 
        }

        [HttpGet]
        public async Task<IActionResult> GetTypesOfEvent() {
            try {
                var typesOfEvent = _typeOfEventServices.GetTypesOfEvents();
                return Ok(typesOfEvent);
            } catch(EntityNotFound error) {
                return NotFound(error.Message);
            }
        }
    }
}