using pharaoh_moto_club.Models;
using Microsoft.EntityFrameworkCore;
using My.Exceptions;

namespace Services {
    public class CandidacyServices {
        private readonly AppDbContext _context;

        public CandidacyServices(AppDbContext context) {
            _context = context;
        }

        public List<int> GetCandidatesByElection(Election election) {
            return  _context.Candidacy.Where(x => x.ElectionId == election.ElectionId).Select(b => b.CandidateId).ToList();
        }

        public async Task SaveCandidacyOnDb(int electionId, int candidateId) {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            var nowBrazilTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            var election = await _context.Elections.FirstOrDefaultAsync(c => c.ElectionId == electionId);
            if (election == null) throw new EntityNotFound("Não foi encontrada nenhuma eleição com o Id fornecido");
            if(election.IsElectionClosed == true || election.EndingOfElection < nowBrazilTime) throw new MemberNotAllowed("Esta eleição já se encerrou ou já se encontra fechada");
            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == candidateId && x.ElectionId == electionId) != null;
            if (doesCandidateExist) throw new MemberNotAllowed("Este candidato já se candidatou para esta eleição");
            var candidacy = new Candidacy(electionId, candidateId);
            _context.Candidacy.Add(candidacy);
            _context.SaveChanges();
        }
    }
}