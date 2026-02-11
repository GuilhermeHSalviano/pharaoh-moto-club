using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
using My.Exceptions;

namespace Entities {
    public class EditElection {
        private readonly AppDbContext _context;

        public EditElection(AppDbContext context) {
            _context = context;
        }

        public async Task EditElectionById(int electionId, ElectionDto updatedElection) {
            var election = await _context.Elections.FindAsync(electionId);
            if(election == null) throw new EntityNotFound("A eleição não foi encontrada!");
            election.BeginningOfElection = updatedElection.BeginningOfElection;
            election.EndingOfElection = updatedElection.EndingOfElection;
            election.PositionToBeElected = updatedElection.PositionToBeElected;

            await _context.SaveChangesAsync();
        }
    }
}