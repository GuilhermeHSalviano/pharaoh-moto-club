using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("elections")]
    public class Election {
        [Key]
        [Column("election_id")]
        public int ElectionId { get; set; }
        [Required]
        [Column("position_to_be_elected")]
        public required string PositionToBeElected { get; set; }
        [Column("beggining_of_election")]
        public DateTime BeginningOfElection { get; set; } = DateTime.Now;
        [Required]
        [Column("ending_of_election")]
        public required DateTime EndingOfElection { get; set; }
        [ForeignKey("winner_id")]
        [Column("winner_id")]
        public int WinnerId {  get; set; }
        [ForeignKey("author_id")]
        [Column("author_id")]
        public required int AuthorId {  get; set; }
        [Column("is_election_closed")]
        public bool IsElectionClosed {get; set;} = false;
    }
}
