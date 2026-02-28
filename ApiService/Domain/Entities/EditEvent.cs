using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
using My.Exceptions;
using Utilities;

namespace Entities {
    public class EditEvent {
        private readonly AppDbContext _context;

        public EditEvent(AppDbContext context) {
            _context = context;
        }

        public async Task EditEventById(int EventId, EventDto updatedEvent, int AuthorId) {
            var Event = await _context.Event.FindAsync(EventId);
            if (Event == null) throw new EntityNotFound("O evento não foi encontrado");
            if (Event.AuthorId != AuthorId) throw new MemberNotAllowed("O evento só pode ser editado pelo seu criador.");
            if(updatedEvent.BeginningOfEvent < BrazilTime.Now()) throw new MemberNotAllowed("O evento não pode ter início em momento passado");
            Event.TypeOfEventId = updatedEvent.TypeOfEventId;
            Event.BeginningOfEvent = updatedEvent.BeginningOfEvent;
            Event.Title = updatedEvent.Title;
            Event.State = updatedEvent.State;
            Event.Description = updatedEvent.Description;

            await _context.SaveChangesAsync();
        }
    }
}