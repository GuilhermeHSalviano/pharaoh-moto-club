using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
using Utilities;

namespace pharaoh_moto_club.Factories {
    static public class CommentFactory {
        public static Comment CreateComment(CommentDto model, int eventId, int authorId) {
            Comment newComment = new Comment {
                CommentText = model.CommentText,
                AuthorId = authorId,
                EventId = eventId,
                CommentDate = BrazilTime.Now()
            };

            return newComment;
        }
    }
}
