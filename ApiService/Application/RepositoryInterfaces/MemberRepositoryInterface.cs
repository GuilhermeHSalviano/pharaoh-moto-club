using pharaoh_moto_club.Models;
namespace RepositoryInterfaces {
    public interface IMemberRepository {
        public Task InsertNewMember(Member model);

    }

}