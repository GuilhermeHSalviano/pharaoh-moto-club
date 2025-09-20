using Microsoft.EntityFrameworkCore;

namespace pharaoh_moto_club.Models {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) {
        }

    }
}
