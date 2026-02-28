
namespace pharaoh_moto_club.Dtos {
    public class CommentDto {
        public required string CommentText { get; set; }
        public required DateTime CommentDate { get; set; }
        public required int AuthorId { get; set; }
    }
}