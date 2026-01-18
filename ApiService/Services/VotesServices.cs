using pharaoh_moto_club.Models;

namespace Services {
    public class VotesServices {
        private readonly AppDbContext _context;

        VotesServices(AppDbContext context) {
            _context = context;
        }
    }

}