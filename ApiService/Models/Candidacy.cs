using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Routing.Matching;

namespace pharaoh_moto_club.Models {
    [Table("candidacy")]
    public class Candidacy {
        [Key]
        [Column("candidacy_id")]
        public int CandidacyId { get; set; }
        [Required]
        [Column("election_id")]
        public int ElectionId {  get; set; }
        public Election Election {get; set;} = null!;
        [Column("candidate_id")]
        [Required]
        public int CandidateId { get; set; }
        public Member Candidate{get; set;} = null!;

        public Candidacy(int electionId, int candidateId) {
            ElectionId = electionId;
            CandidateId = candidateId;
        }
    }

}
