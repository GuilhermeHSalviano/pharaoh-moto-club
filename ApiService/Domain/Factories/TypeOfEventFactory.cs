using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace Factories {
    public class TypeOfEventFactory {
        static public TypeOfEvent CreateTypeOfEvent(TypeOfEventDto model) {
            return new TypeOfEvent {Description = model.Description.Trim()};
        }
    }
}