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

        public async Task<Event> GetEventByIdFromDb(int eventId) {
            var Event = await _context.Event
                .Include(e => e.Comments)
                .Take(50)
                .FirstOrDefaultAsync(e => e.EventId == eventId);
            if(Event == null) throw new EntityNotFound("O evento não foi encontrado!");
            return Event;
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