using pharaoh_moto_club.Models;
using pharaoh_moto_club.Dtos;
using My.Exceptions;
using pharaoh_moto_club.Factories;
using Microsoft.EntityFrameworkCore;


namespace Services {
    public class CommentServices {

        private readonly AppDbContext _context;

        public CommentServices(AppDbContext context) {
            _context = context;
        }

        public async Task SaveCommentOnDb(CommentDto model, int eventId, int authorId) {
            var Event = await _context.Event.FindAsync(eventId);
            if (Event == null) throw new EntityNotFound("O evento não foi encontrado");
            var newComment = CommentFactory.CreateComment(model, eventId, authorId);
            _context.Comment.Add(newComment);
            await _context.SaveChangesAsync();
        }

    }
}