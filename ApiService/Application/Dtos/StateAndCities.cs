
namespace pharaoh_moto_club.Dtos {
    public class StateAndItsCities {
        public required string State { get; set; }
        public int StateId { get; set; }
        public List<CityWithId> Cities {get; set;}
    }

    public class CityWithId {
        public string City { get; set; }
        public int CityId { get; set; }
    }
}