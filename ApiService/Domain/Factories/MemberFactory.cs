using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Factories {
    static public class MemberFactory {
        public static Member CreateMember(MemberDto model) {
            Member newMember = new Member {
                Name = model.Name,
                Nickname = model.Nickname,
                Cpf = model.Cpf,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                CoatOfArms = model.CoatOfArms,
                IsmemberActive = model.IsMemberActive
            };

            return newMember;
        }
    }
}
