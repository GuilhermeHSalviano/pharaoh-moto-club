using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("Voters")]
    public class Voters {
        [Key]
        public int VotersId { get; set; }
        [ForeignKey("MemberId")]
        public int VoterId { get; set;}
        [ForeignKey("ElectionId")]
        public int ElectionId { get; set; }
    }
}
