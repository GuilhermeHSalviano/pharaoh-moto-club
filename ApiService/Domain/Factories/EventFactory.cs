using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Factories {
    static public class EventFactory {
        public static Event CreateEvent(EventDto model) {
            Event newEvent = new Event {
                Title = model.Title,
                State = model.State,
                City = model.City,
                BeginningOfEvent = model.BeginningOfEvent,
                Description = model.Description,
                AuthorId = model.AuthorId,
                TypeOfEventId = model.TypeOfEventId
            };

            return newEvent;
        }
    }
}
