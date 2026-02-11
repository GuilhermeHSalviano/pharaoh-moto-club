using Microsoft.EntityFrameworkCore;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using pharaoh_moto_club.Models;

namespace Services {
    public class VotesServices {
        private readonly AppDbContext _context;

        public VotesServices(AppDbContext context) {
            _context = context;
        }

        public int CountNullVotes(Election election) {
            return _context.Votes.Count(c => c.ElectionId == election.ElectionId && c.CandidateId == null);
        }

        public int CountRejectionVotes(Election election) {
            return _context.Votes.Count(c => c.ElectionId == election.ElectionId && c.IsCandidatesRejected == true);
        }

        public async Task SaveVoteOnDb(CreateVoteDto myVote) {
            var voter = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == myVote.VoterId);
            if (voter == null) throw new EntityNotFound("Este membro votante não existe");
            if (voter.CoatOfArms == false) throw new MemberNotAllowed("Este membro não pode votar, pois não possui brasão");
            var didMemberAlreadyVote = await _context.Votes.FirstOrDefaultAsync(x => x.VoterId == myVote.VoterId && x.ElectionId == myVote.ElectionId) != null;
            if (didMemberAlreadyVote) throw new MemberNotAllowed("Este membro já votou nesta eleição");

            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == myVote.CandidateId && x.ElectionId == myVote.ElectionId) != null;
            if (myVote.IsCandidatesRejected == false && !doesCandidateExist) {
                throw new EntityNotFound("Este candidato não existe");
            }

            if (myVote.IsCandidatesRejected == true && myVote.CandidateId != null) throw new MemberNotAllowed("O membro não pode votar em um candidato e rejeitá-lo ao mesmo tempo");

            _context.Votes.Add(VoteFactory.CreateVote(myVote));

            await _context.SaveChangesAsync();
        }
    }

}