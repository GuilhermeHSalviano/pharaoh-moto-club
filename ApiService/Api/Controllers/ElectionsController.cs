using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ElectionsController : ControllerBase {
        private readonly EditElection _editElection;
        private readonly ElectionServices _electionServices;

        public ElectionsController(EditElection editElection, ElectionServices electionServices) {
            _editElection = editElection;
            _electionServices = electionServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateElection(ElectionDto incomingElection) {
            try {
                await _electionServices.SaveElectionOnDb(incomingElection);
                return NoContent();
            } catch(EntityNotFound error) {
                return NotFound(error.Message);
            } catch(MemberNotAllowed error) {
                return Conflict(error.Message);
            }
        }


        [HttpPut("edit/{ElectionId}")]
        public async Task<IActionResult> EditElection(int electionId, ElectionDto updatedElection) {
            try {
                await _editElection.EditElectionById(electionId, updatedElection);
                return NoContent();
            }
            catch (EntityNotFound error) {
                return NotFound(error.Message);
            }
        }
    }

}

