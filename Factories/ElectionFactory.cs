using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Factories {
    static public class ElectionFactory {
        public static Election CreateElection(ElectionDto model) {
            Election newElection = new Election {
                PositionToBeElected = model.PositionToBeElected,
                BeginningOfElection = model.BeginningOfElection,
                EndingOfElection = model.EndingOfElection,
                AuthorId = model.AuthorId
            };

            return newElection;
        }
    }
}
