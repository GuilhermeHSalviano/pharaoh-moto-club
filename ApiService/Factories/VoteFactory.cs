
using pharaoh_moto_club.Models;
using pharaoh_moto_club.Dtos;

namespace pharaoh_moto_club.Factories
{
    static public class VoteFactory
    {
        public static Votes CreateVote(CreateVoteDto model)
        {
            Votes newVote = new Votes
            {
                VoterId = model.VoterId,
                ElectionId = model.ElectionId,
                CandidateId = model.CandidateId,
                IsCandidatesRejected = model.IsCandidatesRejected            };

            return newVote;
        }
    }
}