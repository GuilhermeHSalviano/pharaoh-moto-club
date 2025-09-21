using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("Candidacy")]
    public class Candidacy {
        [Key]
        public int CandidacyId { get; set; }
        [Required]
        [ForeignKey("ElectionId")]
        public int ElectionId {  get; set; }
        [ForeignKey("MemberId")]
        public int VoterId { get; set; }
    }
}
