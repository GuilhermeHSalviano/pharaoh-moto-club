using Microsoft.EntityFrameworkCore;
using My.Exceptions;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using pharaoh_moto_club.Models;

namespace Services {
    public class MemberServices {
        private readonly AppDbContext _context;

        public MemberServices(AppDbContext context) {
            _context = context;
        }

        public async Task InsertNewMemberOnDb(MemberDto model) {
            var doesMemberAlreadyExist = await _context.Members.FirstOrDefaultAsync(c => c.Cpf == model.Cpf) != null;
            if (doesMemberAlreadyExist) throw new EntityAlreadyExists("O membro já existe");
            Member newMember = MemberFactory.CreateMember(model);
            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();
        }
    }
}