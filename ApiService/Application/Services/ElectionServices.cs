using pharaoh_moto_club.Models;
using Utilities;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Dtos;
using My.Exceptions;
using pharaoh_moto_club.Factories;


namespace Services {
    public class ElectionServices {

        private readonly AppDbContext _context;

        public ElectionServices(AppDbContext context) {
            _context = context;
        }

        public async Task<Election?> GetFinishedNotClosedElection() {
            return await _context.Elections.Where(x => x.IsElectionClosed == false && x.EndingOfElection < BrazilTime.Now()).FirstOrDefaultAsync();
        }

        public async Task<Election?> GetElectionById(int electionId) {
            return await _context.Elections.FindAsync(electionId);
        }

        public async Task SaveElectionOnDb(ElectionDto incomingElection) {
            var election = await _context.Elections.FirstOrDefaultAsync(b => b.PositionToBeElected == incomingElection.PositionToBeElected && b.IsElectionClosed == false);
            var author = await _context.Members.FirstOrDefaultAsync(b => b.MemberId == incomingElection.AuthorId);
            if(incomingElection.BeginningOfElection > incomingElection.EndingOfElection) throw new MemberNotAllowed("Início da eleição não pode ser posterior ao final da eleição");
            if(incomingElection.EndingOfElection <= BrazilTime.Now()) throw new MemberNotAllowed("O início da eleição deve ser posterior ao momento atual");
            if (author == null) throw new EntityNotFound("O autor informado não existe"); 
            if (election != null) throw new MemberNotAllowed("Já existe uma eleição aberta para este cargo"); 
            Election newElection = ElectionFactory.CreateElection(incomingElection);
            _context.Elections.Add(newElection);
            await _context.SaveChangesAsync();
        }
        
    }
    
}