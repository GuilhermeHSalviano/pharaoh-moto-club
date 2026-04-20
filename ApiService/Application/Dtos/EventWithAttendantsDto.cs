using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Dtos {
    public class EventWithAttendantsDto {

        public required EventDto Event { get; set; }
        public required IQueryable<string> Attendants { get; set; }
        public required IQueryable<CommentWithNicknameDto> Comments {get; set;}

    }
}
