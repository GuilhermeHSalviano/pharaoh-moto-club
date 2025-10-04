using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ElectionsController : ControllerBase {
        private readonly AppDbContext _context;

        public ElectionsController(AppDbContext context) {
            _context = context;
        }

        public class VotesPerCandidate {

            public int candidateId { get; set; }
            public int votesReceived { get; set; }
            public VotesPerCandidate(int id, int votes) {
                candidateId = id;
                votesReceived = votes;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateElection(Election model) {
            _context.Elections.Add(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{ElectionId}")]
        public async Task<IActionResult> CloseElection(int electionId, List<int> Candidates) {
            var election = await _context.Elections.FindAsync(electionId);
            if (election == null) return NotFound();
            var counting = new List<VotesPerCandidate>();
            var nullVotes = _context.Votes.Count(c => c.ElectionId == electionId && c.CandidateId == null);
            var even = false;
            VotesPerCandidate possibleWinner = new VotesPerCandidate(0, 0);

            for (int i = 0; i < Candidates.Count; i++) {
                var votes = _context.Votes
                    .Count(c => c.CandidateId == Candidates[i] && c.ElectionId == electionId);
                var candidateVotes = new VotesPerCandidate(Candidates[i], votes);
                counting.Add(candidateVotes);
            }

            if (Candidates.Count == 1) {
                election.WinnerId = counting[0].votesReceived > nullVotes ? counting[0].candidateId : 0;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            for(int i = 0; i < counting.Count; i++) {
                if (counting[i].candidateId > possibleWinner.votesReceived) {
                    possibleWinner = counting[i];
                    even = false;
                } else if(counting[i].votesReceived == possibleWinner.votesReceived) {
                    even = true;
                }
            }

            if(even = true) {
                election.WinnerId = 0;
                await _context.SaveChangesAsync();
                return NoContent();
            } else {
                election.WinnerId = possibleWinner.candidateId;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}

