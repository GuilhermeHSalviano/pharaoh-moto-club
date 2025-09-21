using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("Elections")]
    public class Election {
        [Key]
        public int ElectionId { get; set; }
        [Required]
        public required string PositionToBeElected { get; set; }
        public DateTime BeginningOfElection { get; set; } = DateTime.Now;
        [Required]
        public required DateTime EndingOfElection { get; set; }
        [ForeignKey("MemberId")]
        public int WinnerId {  get; set; }
        [ForeignKey("MemberId")]
        public int AuthorId {  get; set; }
    }
}
