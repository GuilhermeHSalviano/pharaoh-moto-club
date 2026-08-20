using Microsoft.EntityFrameworkCore.Metadata;

namespace pharaoh_moto_club.Dtos {
    public class RefreshTokenDto {
        public required string RefreshTokenString {get; set;}
        public required DateTime CreatedAt {get; set;}
        public required DateTime ExpiresAt {get; set;}
        public required int MemberId {get; set;}
    }

}