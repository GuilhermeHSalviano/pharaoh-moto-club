using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    [Table("comment")]
    public class Comment {
        [Key]
        [Column("comment_id")]
        public int CommentId { get; set; }
        [Column("comment_text")]
        public required string CommentText { get; set; }
        [Column("comment_date")]
        public required DateTime CommentDate { get; set; }
        [Column("author_id")]
        public required int AuthorId { get; set; }
        public required Member Author { get; set; } = null!;
    }
}
