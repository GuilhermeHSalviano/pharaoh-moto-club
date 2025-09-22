using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace pharaoh_moto_club.Models {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Candidacy> Candidacy { get; set; }
        public DbSet<Votes> Votes { get; set; }
    }
}
