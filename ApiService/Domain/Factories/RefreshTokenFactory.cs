using System.Security.Cryptography;
using pharaoh_moto_club.Models;
using Utilities;

namespace pharaoh_moto_club.Factories {
    static public class RefreshTokenFactory {


        static public RefreshToken CreateRefreshToken(int memberId, int expirationMinutes, string refreshTokenString) {
            RefreshToken newRefreshToken = new RefreshToken {
                RefreshTokenHash = refreshTokenString,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes),
                MemberId = memberId
            };

            return newRefreshToken;
        }
    }
}