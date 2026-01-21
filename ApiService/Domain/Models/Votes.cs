using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Net.Http.Headers;

namespace pharaoh_moto_club.Models {
    [Table("votes")]
    public class Votes {
        [Key]
        [Column("vote_id")]
        public int VoteId { get; set; }
        [Column("voter_id")]
        public int VoterId { get; set;}
        [ForeignKey(nameof(VoterId))]
        public Member Voter {get; set;} = null!;
        [Column("election_id")]
        public int ElectionId { get; set; }
        [ForeignKey(nameof(ElectionId))]
        public Election Election {get; set;} = null!;
        [Column("candidate_id")]
        public int? CandidateId { get; set; }
        [ForeignKey(nameof(CandidateId))]
        public Member? Candidate {get; set;} = null!;
        [Column("is_candidates_rejected")]
        public bool IsCandidatesRejected { get; set; }

        public Votes() { }

        public Votes(int voterId, int electionId, int? candidateId, bool isCandidatesRejected) {
            VoterId = voterId;
            ElectionId = electionId;
            CandidateId = candidateId;
            IsCandidatesRejected = isCandidatesRejected;
        }
    }

}
