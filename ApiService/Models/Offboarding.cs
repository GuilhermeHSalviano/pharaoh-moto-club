using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models
{
    [Table("offboardings")]
    public class Offboarding
    {
        [Key]
        [Column("offboarding_id")]
        public int OffboardingId {get; set;}
        [Column("member_id")]
        public required int MemberId {get; set;}
        public required Member Member {get; set;}
        [Column("offboarding_beggining")]
        public DateTime OffboardingBeggining {get; set;}
        [Column("offboarding_end")]
        public DateTime OffboardingEnd {get; set;}
    }
}