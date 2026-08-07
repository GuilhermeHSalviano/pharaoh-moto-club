using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Utilities;


namespace pharaoh_moto_club.Models {
    [Table("refresh_token")]
    public class RefreshToken {
        [Key]
        [Column("refresh_token_id")]
        public int RefreshTokenId { get; set; } 
        [Column("refresh_token_hash")]
        public string RefreshTokenHash { get; set; } = string.Empty;
        [Column("created_at")]
        public DateTime CreatedAt {get; set;}
        [Column("expires_at")]
        public DateTime ExpiresAt {get; set;}
        [Column("revoked_at")]
        public DateTime? RevokedAt {get; set;} = null;
        [Column("member_id")]
        public required int MemberId {get; set;}
        public Member Member {get; set;} = null!;
        [Column("replaced_by_token")]
        public string? ReplacedByToken {get; set;}
        public bool IsActive => RevokedAt is null && BrazilTime.Now() < ExpiresAt;
       
    }
}