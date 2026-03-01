using pharaoh_moto_club.Models;
using Utilities;
using pharaoh_moto_club.Dtos;
using My.Exceptions;
using pharaoh_moto_club.Factories;
using Microsoft.EntityFrameworkCore;


namespace Services {
    public class EventServices {

        private readonly AppDbContext _context;

        public EventServices(AppDbContext context) {
            _context = context;
        }

        public async Task SaveEventOnDb(EventDto model) {
            if(model.BeginningOfEvent < BrazilTime.Now()) throw new MemberNotAllowed("O início do evento deve ser posterior ao momento atual");
            var newEvent = EventFactory.CreateEvent(model);
            _context.Event.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<EventWithAttendantsDto> GetEventByIdFromDb(int eventId) {
            var Event = await _context.Event
                .FirstOrDefaultAsync(e => e.EventId == eventId);
            if(Event == null) throw new EntityNotFound("O evento não foi encontrado");
            if(Event == null) throw new EntityNotFound("O evento não foi encontrado!");

            var attedants = _context.EventAttendants
                .Where(c => c.EventId == Event.EventId)
                .Join(_context.Members,
                    c => c.AttendantId,
                    m => m.MemberId,
                    (c,m) => m.Nickname
                );

            var comments = _context.Comment
                .Where(c => c.EventId == eventId)
                .Join(_context.Members,
                    c => c.AuthorId,
                    m => m.MemberId,
                    (c,m) => new CommentWithNicknameDto {
                        CommentText = c.CommentText,
                        Author = m.Nickname
                    }
                );

            var newEventWithAttendants = new EventWithAttendantsDto {
                Event = Event,
                Attendants = attedants,
                Comments = comments
            };
            
            return newEventWithAttendants;
        }

        public List<string> GetAllFutureEventStatesFromDb() {
            var states =  _context.Event
                .Where(c => c.BeginningOfEvent > BrazilTime.Now().Date)
                .Select(s => s.State)
                .Distinct()
                .ToList();
            if(states == null) return new List<string>();
            return states;
        }

        public List<string> GetAllFutureEventCitiesFromDb(string state) {
            var states =  _context.Event
                .Where(c => c.BeginningOfEvent > BrazilTime.Now().Date && c.State == state)
                .Select(s => s.City)
                .Distinct()
                .ToList();
            if(states == null) return new List<string>();
            return states;
        }

        public List<Event> GetAllFutureEventsByCityFromDb(int cityId) {
            var events = _context.Event
                .Where(c => c.CityId == cityId)
                .ToList();

            if(events.Count == 0) throw new EntityNotFound("Não foram encontrados eventos nesta cidade");

            return events;
        }
        
    }
    
}