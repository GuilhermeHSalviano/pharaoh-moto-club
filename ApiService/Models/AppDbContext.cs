using Microsoft.EntityFrameworkCore;

namespace pharaoh_moto_club.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Board)
                .WithMany()
                .HasForeignKey(m => m.BoardId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Board>()
                .HasOne(b => b.BoardLeader)
                .WithMany()
                .HasForeignKey(b => b.BoardLeaderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Election>()
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Election>()
                .HasOne(e => e.Winner)
                .WithMany()
                .HasForeignKey(e => e.WinnerId)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Candidacy> Candidacy { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<Offboarding> Offboarding { get; set; }
    }
}
