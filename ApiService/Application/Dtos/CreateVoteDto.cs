namespace pharaoh_moto_club.Dtos
{
    public class CreateVoteDto
    {
        public int VoterId { get; set; }
        public int ElectionId { get; set; }
        public int? CandidateId { get; set; }
        public bool IsCandidatesRejected { get; set; }
    }
}
