namespace pharaoh_moto_club.Dtos {
    public class EventDto {
        public required string Title { get; set; }
        public required int StateId { get; set; }
        public required string State { get; set; }
        public required int CityId { get; set; }
        public required string City { get; set; }
        public required DateTime BeginningOfEvent { get; set; }
        public required string Description { get; set; }
        public required int AuthorId { get; set; }
        public required int TypeOfEventId { get; set; }
        public string? AuthorName {get; set;}
        public int? EventId {get; set;}
    }

    public class EventWithDateLocationAndTitleDto {
        public required string Title {get; set;}
        public required int StateId { get; set; }
        public required string State { get; set; }
        public required int CityId { get; set; }
        public required string City { get; set; }
        public required DateTime BeginningOfEvent { get; set; }
    }
}