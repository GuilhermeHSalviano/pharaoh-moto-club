using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Factories {
    static public class ClaimsFactory {


        static public MemberClaimsDto CreateMemberClaims(Member member) {
            MemberClaimsDto newMemberClaims = new MemberClaimsDto {
               MemberId = member.MemberId,
               Nickname = member.Nickname,
               Name = member.Name
            };

            return newMemberClaims;
        }
    }
}