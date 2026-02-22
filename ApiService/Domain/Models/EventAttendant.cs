using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("event_attendant")]
    public class EventAttendant {
        [Key]
        [Column("event_attendant_id")]
        public int EventAttendantId { get; set; }

        [Column("attendant_id")]
        public required int AttendantId {get; set;}
        public Member Attendant {get; set;} = null!;

        [Column("event_id")]
        public required int EventId {get; set;}
        public Event Event {get; set;} = null!;
    }
}