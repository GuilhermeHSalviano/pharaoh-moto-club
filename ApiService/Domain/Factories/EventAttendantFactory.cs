using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Factories {
    static public class EventAttendantFactory {
        public static EventAttendant CreateEventAttendant(int eventId, int attendantId) {
            EventAttendant newEventAttendant = new EventAttendant {
                EventId = eventId,
                AttendantId = attendantId
            };

            return newEventAttendant;
        }
    }
}
