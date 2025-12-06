using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("votes")]
    public class Votes {
        [Key]
        public int VoteId { get; set; }
        [ForeignKey("voter_id")]
        public int VoterId { get; set;}
        [ForeignKey("election_id")]
        public int ElectionId { get; set; }
        [ForeignKey("candidate_id")]
        public int? CandidateId { get; set; }
        [Column("is_candidates_rejected")]
        public bool IsCandidatesRejected { get; set; }

        public Votes() { }

        public Votes(int voterId, int electionId, int candidateId, bool isCandidatesRejected) {
            VoterId = voterId;
            ElectionId = electionId;
            CandidateId = candidateId;
            IsCandidatesRejected = isCandidatesRejected;
        }
    }

}
