using System.Security.Cryptography;
using System.Text;

namespace Utilities {
    public class BrazilTime {
        public static DateTime Now() {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
        }
    }

    public class TokenUtilities {
        public static string HashToken(string tokenString) {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(tokenString);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static string CreateRefreshTokenString() {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}