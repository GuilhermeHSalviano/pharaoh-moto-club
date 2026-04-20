using pharaoh_moto_club.Models;
using Utilities;
using pharaoh_moto_club.Dtos;
using My.Exceptions;
using pharaoh_moto_club.Factories;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Migrations;


namespace Services {
    public class EventServices {

        private readonly AppDbContext _context;

        public EventServices(AppDbContext context) {
            _context = context;
        }

        public async Task SaveEventOnDb(EventDto model) {
            if (model.BeginningOfEvent < BrazilTime.Now()) throw new MemberNotAllowed("O início do evento deve ser posterior ao momento atual");
            var newEvent = EventFactory.CreateEvent(model);
            _context.Event.Add(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<EventWithAttendantsDto> GetEventByIdFromDb(int eventId) {
            var Event = await _context.Event
                .Where(e => e.EventId == eventId)
                .Select(c => new EventDto {
                    Title = c.Title,
                        StateId = c.StateId,
                        State = c.State,
                        CityId = c.CityId,
                        City = c.City,
                        BeginningOfEvent = c.BeginningOfEvent,
                        Description = c.Description,
                        AuthorId = c.AuthorId,
                        TypeOfEventId = c.TypeOfEventId,
                        AuthorName = c.Author.Nickname,
                        EventId = c.EventId
                })
                .FirstOrDefaultAsync();
            
            if (Event == null) throw new EntityNotFound("O evento não foi encontrado");
            if (Event == null) throw new EntityNotFound("O evento não foi encontrado!");

            var attedants = _context.EventAttendants
                .Where(c => c.EventId == Event.EventId)
                .Join(_context.Members,
                    c => c.AttendantId,
                    m => m.MemberId,
                    (c, m) => m.Nickname
                );

            var comments = _context.Comment
                .Where(c => c.EventId == eventId)
                .Join(_context.Members,
                    c => c.AuthorId,
                    m => m.MemberId,
                    (c, m) => new CommentWithNicknameDto {
                        CommentText = c.CommentText,
                        Author = m.Nickname,
                        CommentDate = c.CommentDate
                    }
                );

            var newEventWithAttendants = new EventWithAttendantsDto {
                Event = Event,
                Attendants = attedants,
                Comments = comments
            };

            return newEventWithAttendants;
        }

        public List<StateAndItsCities> GetAllFutureEventStatesFromDb() {
            var states = _context.Event
                .Where(c => c.BeginningOfEvent > BrazilTime.Now().Date)
                .Select(s => new { s.State, s.StateId })
                .Distinct()
                .ToList();
            if (states == null) return new List<StateAndItsCities>();
            var statesAndCities = new List<StateAndItsCities>();
            foreach (var entity in states) {
                StateAndItsCities stateAndCity = new StateAndItsCities() {
                    State = entity.State,
                    StateId = entity.StateId
                };
                var cities = GetAllFutureEventCitiesFromDb(entity.State);

                stateAndCity.Cities = cities;
                statesAndCities.Add(stateAndCity);
            }
            return statesAndCities;
        }

        public List<CityWithId> GetAllFutureEventCitiesFromDb(string state) {
            var result = _context.Event
                .Where(c => c.BeginningOfEvent > BrazilTime.Now().Date && c.State == state)
                .Select(s => new { s.City, s.CityId })
                .Distinct()
                .ToList();
            if (result == null) return new List<CityWithId>();
            var cityWithIdList = new List<CityWithId>();
            foreach (var element in result) {
                CityWithId city = new CityWithId() {
                    City = element.City,
                    CityId = element.CityId
                };
                cityWithIdList.Add(city);   
            }
            return cityWithIdList;
        }

        public List<Event> GetAllFutureEventsByCityFromDb(int cityId) {
            var events = _context.Event
                .Where(c => c.CityId == cityId)
                .ToList();

            if (events.Count == 0) throw new EntityNotFound("Não foram encontrados eventos nesta cidade");

            return events;
        }

    }

}