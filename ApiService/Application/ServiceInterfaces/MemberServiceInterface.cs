using pharaoh_moto_club.Dtos;

namespace ServiceInterfaces {
    public interface IMemberServices {
        public Task InsertNewMemberOnDb(MemberDto model);
    };
}