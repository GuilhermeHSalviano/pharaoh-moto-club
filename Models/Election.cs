using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("elections")]
    public class Election {
        [Key]
        [Column("election_id")]
        public int ElectionId { get; set; }
        [Column("position_to_be_elected")]
        public required string PositionToBeElected { get; set; }
        [Column("beggining_of_election")]
        public required DateTime BeginningOfElection { get; set; }
        [Column("ending_of_election")]
        public required DateTime EndingOfElection { get; set; }
        [Column("winner_id")]
        public int? WinnerId {  get; set; }
        public Member? Winner {get; set;}
        [Column("author_id")]
        [Required]
        public int AuthorId {  get; set; }
        public Member Author {get; set;} = null!;
        [Column("is_election_closed")]
        public bool IsElectionClosed {get; set;} = false;
    }
}
