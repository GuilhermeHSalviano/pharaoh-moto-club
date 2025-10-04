using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("Candidacy")]
    public class Candidacy {
        [Key]
        [Column("candidacy_id")]
        public int CandidacyId { get; set; }
        [Required]
        [ForeignKey("election_id")]
        [Column("election_id")]
        public int ElectionId {  get; set; }
        [ForeignKey("candidate_id")]
        [Column("candidate_id")]
        public int CandidateId { get; set; }

        public Candidacy(int electionId, int candidateId) {
            ElectionId = electionId;
            CandidateId = candidateId;
        }
    }

}
