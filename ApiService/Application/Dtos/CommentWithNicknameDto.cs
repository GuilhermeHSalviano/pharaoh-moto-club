
namespace pharaoh_moto_club.Dtos {
    public class CommentWithNicknameDto {
        public required string CommentText { get; set; }
        public required string Author { get; set; }
        public required DateTime CommentDate {get; set;}
    }
}