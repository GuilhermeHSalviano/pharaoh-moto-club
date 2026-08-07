using System.Security.Cryptography;
using pharaoh_moto_club.Models;
using Utilities;

namespace pharaoh_moto_club.Factories {
    static public class RefreshTokenFactory {


        static public RefreshToken CreateRefreshToken(int memberId, int expirationMinutes) {
            RefreshToken newRefreshToken = new RefreshToken {
                RefreshTokenString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes),
                MemberId = memberId
            };

            return newRefreshToken;
        }
    }
}