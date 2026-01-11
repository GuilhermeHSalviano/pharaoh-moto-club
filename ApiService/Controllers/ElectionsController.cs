using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
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
        public async Task<IActionResult> CreateElection(ElectionDto model) {
            var election = await _context.Elections.FirstOrDefaultAsync(b => b.PositionToBeElected == model.PositionToBeElected && b.IsElectionClosed == false);
            var author = await _context.Members.FirstOrDefaultAsync(b => b.MemberId == model.AuthorId);
            if (author == null) return NotFound("O autor informado não existe");
            if (election != null) return Conflict("Já existe uma eleição aberta para este cargo");
            Election newElection = ElectionFactory.CreateElection(model);
            _context.Elections.Add(newElection);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetFinishedElection() {
            var finishedElection = await _context.Elections.Where(x => x.IsElectionClosed == false && x.EndingOfElection < DateTime.Now).FirstOrDefaultAsync();
            if(finishedElection == null) {
                return Ok(finishedElection);
            }
            else {
                return Ok(finishedElection.ElectionId);
            }
        }

        [HttpPut("{ElectionId}")]
        public async Task<IActionResult> CloseElection(int electionId) {
            var election = await _context.Elections.FindAsync(electionId);
            if (election == null) return NotFound("Eleição não encontrada");
            if (election.IsElectionClosed == true) return Conflict("Esta eleição já está fechada");
            var candidates = _context.Candidacy.Where(x => x.ElectionId == electionId).Select(b => b.CandidateId).ToList();
            var counting = new List<VotesPerCandidate>();
            var nullVotes = _context.Votes.Count(c => c.ElectionId == electionId && c.CandidateId == null);
            var rejectionVotes = _context.Votes.Count(c => c.ElectionId == electionId && c.IsCandidatesRejected == true);
            var tie = false;
            VotesPerCandidate possibleWinner = new VotesPerCandidate(0, 0);

            for (int i = 0; i < candidates.Count; i++) {
                var votes = _context.Votes
                    .Count(c => c.CandidateId == candidates[i] && c.ElectionId == electionId);
                var candidateVotes = new VotesPerCandidate(candidates[i], votes);
                counting.Add(candidateVotes);
            }

            if(counting.Count == 0) {
                election.IsElectionClosed = true;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            if (candidates.Count == 1 && candidates.Count > rejectionVotes) {
                election.WinnerId = counting[0].votesReceived > nullVotes ? counting[0].candidateId : 0;
                election.IsElectionClosed = true;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            for (int i = 0; i < counting.Count; i++) {
                if (counting[i].votesReceived > possibleWinner.votesReceived) {
                    possibleWinner = counting[i];
                    tie = false;
                }
                else if (counting[i].votesReceived == possibleWinner.votesReceived) {
                    tie = true;
                }
            }

            if (tie == true || possibleWinner.votesReceived < rejectionVotes) {
                election.WinnerId = 0;
            }
            else {
                election.WinnerId = possibleWinner.candidateId;
            }

            election.IsElectionClosed = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("edit/{ElectionId}")]
        public async Task<IActionResult> EditElection(int electionId, ElectionDto updatedElection) {
            var election = await _context.Elections.FindAsync(electionId);
            if (election == null) return NotFound();
            election.BeginningOfElection = updatedElection.BeginningOfElection;
            election.EndingOfElection = updatedElection.EndingOfElection;
            election.PositionToBeElected = updatedElection.PositionToBeElected;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{electionId}")]
        public async Task<IActionResult> GetVotesByElection(int electionId) {
            if (await _context.Elections.FindAsync(electionId) == null) return NotFound("Eleição não encontrada");
            var votes = await _context.Votes.Where(x => x.ElectionId == electionId).ToListAsync();
            return Ok(votes);
        }
    }

}

