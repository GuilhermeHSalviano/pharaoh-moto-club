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
                City = model.City,
                State = model.State,
                StatesVisited = model.StatesVisited,
                EntryDate = model.EntryDate,
                Triennium = model.Triennium,
                HasBeenAbroad = model.HasBeenAbroad,
                BirthDate = model.BirthDate,
                IsFirst = model.IsFirst,
                WifeName = model.Wifename,
                WifeNickname = model.WifeNickname,
                CoatOfArms = model.CoatOfArms,
                ProfilePhoto = model.ProfilePhoto,
                MotorcycleSign = model.MotorcycleSign,
                MotorcycleBrand = model.MotorcycleBrand,
                MotorcycleName = model.MotorcycleName,
                MotorcycleNickName = model.MotorcycleNickName,
                BoardId = model.BoardId,
            };

            return newMember;
        }
    }
}
