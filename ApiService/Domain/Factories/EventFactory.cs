using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Factories {
    static public class EventFactory {
        public static Event CreateEvent(EventDto model) {
            Event newEvent = new Event {
                Title = model.Title.Trim(),
                State = model.State.Trim(),
                CityId = model.CityId,
                StateId = model.StateId,
                City = model.City.Trim(),
                BeginningOfEvent = model.BeginningOfEvent,
                Description = model.Description.Trim(),
                AuthorId = model.AuthorId,
                TypeOfEventId = model.TypeOfEventId
            };

            return newEvent;
        }
    }
}
