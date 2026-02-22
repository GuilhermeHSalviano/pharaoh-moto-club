using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("type_of_event")]
    public class TypeOfEvent {
        [Key]
        [Column("type_of_event_id")]
        public int TypeOfEventId { get; set; }
        [Column("description")]
        public required string Description { get; set; }
    }
}
