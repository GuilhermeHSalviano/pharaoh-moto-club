using System.Security.Cryptography;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Models;
using Utilities;

namespace pharaoh_moto_club.Factories {
    static public class RefreshTokenFactory {


        static public RefreshTokenDto CreateRefreshTokenDto(int memberId, int expirationMinutes, string refreshTokenString) {
            RefreshTokenDto newRefreshTokenDto = new RefreshTokenDto {
                RefreshTokenString = refreshTokenString,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes),
                MemberId = memberId
            };

            return newRefreshTokenDto;
        }

        static public RefreshToken CreateRefreshToken(RefreshTokenDto refreshTokenDto) {
            RefreshToken newRefreshToken = new RefreshToken {
                RefreshTokenHash = TokenUtilities.HashToken(refreshTokenDto.RefreshTokenString),
                CreatedAt = refreshTokenDto.CreatedAt,
                ExpiresAt = refreshTokenDto.ExpiresAt,
                MemberId = refreshTokenDto.MemberId
            };

            return newRefreshToken;
        }
    }
}