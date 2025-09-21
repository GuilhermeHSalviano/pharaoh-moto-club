using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("Boards")]
    public class Board {
        [Key]
        public int BoardId { get; set; }
        [ForeignKey("MemberId")]
        public int? BoardLeaderId {  get; set; }
        [Required]
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
