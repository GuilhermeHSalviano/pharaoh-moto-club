using pharaoh_moto_club.Models;
using My.Exceptions;
using pharaoh_moto_club.Factories;
using Microsoft.EntityFrameworkCore;


namespace Services {
    public class EventAttendantServices {

        private readonly AppDbContext _context;

        public EventAttendantServices(AppDbContext context) {
            _context = context;
        }

        public async Task SaveAttendantOnDb(int eventId, int attendantId) {
            var checkIfAttendantExists = await _context.Members.FindAsync(attendantId);
            var checkIfEventExists = await _context.Event.FindAsync(eventId);
            if(checkIfAttendantExists == null || checkIfEventExists == null) throw new EntityNotFound("Evento ou membro não encontrado");
            var checkIfEventAttendantExists = await _context.EventAttendants.AnyAsync(c => c.EventId == eventId && c.AttendantId == attendantId);
            if(checkIfEventAttendantExists) throw new MemberNotAllowed("O membro já se cadastrou como participante do evento" + checkIfAttendantExists.Nickname);
            var newEventAttendant = EventAttendantFactory.CreateEventAttendant(eventId, attendantId);
            _context.EventAttendants.Add(newEventAttendant);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendantOnDb(int eventId, int attendantId) {
            var checkIfAttendantExists = await _context.Members.FindAsync(attendantId);
            var checkIfEventExists = await _context.Event.FindAsync(eventId);
            if(checkIfAttendantExists == null || checkIfEventExists == null) throw new EntityNotFound("Evento ou membro não encontrado");
            var eventAttendant = await _context.EventAttendants.FirstOrDefaultAsync(c => c.EventId == eventId && c.AttendantId == attendantId);
            if(eventAttendant != null) {
                _context.EventAttendants.Remove(eventAttendant);
                _context.SaveChanges();
            }
            else {
                throw new EntityNotFound("O membro não se candidatou para o evento informado");
            }
            
        }
    }
}