namespace pharaoh_moto_club.Models {
    public class VotesPerCandidate {

        public int candidateId { get; set; }
        public int votesReceived { get; set; }
        public VotesPerCandidate(int id, int votes) {
            candidateId = id;
            votesReceived = votes;
        }
    }
}
