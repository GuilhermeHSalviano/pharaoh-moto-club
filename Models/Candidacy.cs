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
        [ForeignKey("voter_id")]
        [Column("voter_id")]
        public int VoterId { get; set; }
    }
}
