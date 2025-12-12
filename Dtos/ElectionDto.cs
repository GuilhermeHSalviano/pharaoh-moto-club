using pharaoh_moto_club.Migrations;

namespace pharaoh_moto_club.Dtos {
    public class ElectionDto {
        public required string PositionToBeElected { get; set; }
        public DateTime BeginningOfElection {  get; set; }
        public DateTime EndOfElection { get; set; }
    }
}
