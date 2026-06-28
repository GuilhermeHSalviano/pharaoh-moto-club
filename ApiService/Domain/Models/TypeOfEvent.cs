using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pharaoh_moto_club.Models {
    [Table("type_of_event")]
    [Index(nameof(Description), IsUnique = true)]
    public class TypeOfEvent {
        [Key]
        [Column("type_of_event_id")]
        public int TypeOfEventId { get; set; }
        [Column("description")]
        public required string Description { get; set; }
    }
}
