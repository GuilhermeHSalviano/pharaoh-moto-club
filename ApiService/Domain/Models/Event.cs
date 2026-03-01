using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("events")]
    public class Event {
        [Key]
        [Column("event_id")]
        public int EventId { get; set; }
        [Column("title")]
        public required string Title {get; set;}
        [Column("state_id")]
        public required int StateId { get; set; }
        [Column("state")]
        public required string State {get; set;}
        [Column("city_id")]
        public required int CityId { get; set; }
        [Column("city")]
        public required string City {get; set;}
        [Column("beginning_of_event")]
        public required DateTime BeginningOfEvent {get; set;}
        [Column("description")]
        public required string Description {get; set;}

        [Column("author_id")]
        public required int AuthorId {get; set;}
        public Member Author {get; set;} = null!;


        [Column("type_of_event_id")]
        public required int TypeOfEventId {get; set;}
        public TypeOfEvent TypeOfEvent {get; set;} = null!;
        
        public ICollection<Comment>? Comments {get; set;} = new List<Comment>();
    }
}
