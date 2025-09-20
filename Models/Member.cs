using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pharaoh_moto_club.Models {
    public class Member {
        [Key]
        public int MemberId { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string NickName {  get; set; }
        [Required]
        public required string Cpf {  get; set; }
        public DateTime EntryDate {  get; set; }
        public Rank? Rank {  get; set; }
        public int Triennium { get; set; }
        public bool HasHeBeenAbroad {  get; set; }
        [ForeignKey("MemberId")]
        public int? BoardLeader {  get; set; }
        public DateTime BirthDate { get; set; }
        public string? City { get; set; }
        public bool IsHeFirst { get; set; } = false;
        public string? WifeName { get; set; }
        public string? WifeNickName { get; set; }
        public bool CoatOfArms { get; set; }
        public bool OffBoarding {  get; set; }
        public byte[]? ProfilePhoto { get; set; }
        public string? MotorCycleSign { get; set; }
        public string? MotorCycleBrand { get; set; }
        public string? MotorCycleName { get; set; }
        public string? MotorCycleNickName {  get; set; }
        public bool IsheActive { get; set; } = true;
    }

    public enum Rank {
        Suporte,
        Prospect,
        Presidente,
        VicePresidente,
        DiretorRegional,
        DiretorEstadual,
        Guardiao,
        DiretorAdministrativo,
        DiretorFinanceiro,
        MembroDiretoriaFinanceira,
        MembroDiretoriaAdministrativa
    }git 
}
