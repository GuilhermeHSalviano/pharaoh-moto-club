using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Utilities;

namespace pharaoh_moto_club.Models {
    [Table("comment")]
    public class Comment {
        [Key]
        [Column("comment_id")]
        public int CommentId { get; set; }
        [Column("comment_text")]
        public required string CommentText { get; set; }
        [Column("comment_date")]
        public required DateTime CommentDate { get; set;}

        [Column("event_id")]
        public required int EventId {get; set;}
        [JsonIgnore]
        public Event Event {get; set;} = null!;
        
        
        [Column("author_id")]
        public required int AuthorId { get; set; }
        [JsonIgnore]
        public Member Author { get; set; } = null!;
    }
}
