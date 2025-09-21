using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace pharaoh_moto_club.Models {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
