using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("boards")]
    public class Board {
        [Key]
        [Column("board_id")]
        public int BoardId { get; set; }
        [ForeignKey("board_leader_id")]
        [Column("board_leader_id")]
        public int? BoardLeaderId {  get; set; }
        [Required]
        [Column("board_type")]
        public required BoardType BoardType { get; set; }
    }

    public enum BoardType {
        MesaDeGuardiao,
        DiretoriaAdministrativa,
        DiretoriaFinanceira,
        DiretoriaRegional,
        DiretoriaEstadual
    }
}
