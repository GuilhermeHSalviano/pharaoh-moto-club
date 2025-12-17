using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models
{
    [Table("boards")]
    public class Board
    {
        [Key]
        [Column("board_id")]
        public int BoardId { get; set; }
        [Column("board_leader_id")]
        [Required]
        public int BoardLeaderId { get; set; }
        public Member BoardLeader { get; set; } = null!;
    }
}
