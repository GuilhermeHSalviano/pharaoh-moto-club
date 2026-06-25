using pharaoh_moto_club.Models;
using RepositoryInterfaces;
namespace Repositories {
    class MemberRepository : IMemberRepository {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context) {
            _context = context;
        }

        public async Task InsertNewMember(Member model) {
            _context.Members.Add(model);
            await _context.SaveChangesAsync();
        }
    }
}