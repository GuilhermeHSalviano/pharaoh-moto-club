using pharaoh_moto_club.Models;
using Utilities;
using pharaoh_moto_club.Dtos;
using My.Exceptions;
using pharaoh_moto_club.Factories;


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
        
    }
    
}