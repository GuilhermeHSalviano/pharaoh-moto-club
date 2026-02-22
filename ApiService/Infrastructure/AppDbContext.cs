using Microsoft.EntityFrameworkCore;

namespace pharaoh_moto_club.Models {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model
             .GetEntityTypes()
             .SelectMany(e => e.GetForeignKeys())) {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Election>()
                .HasOne(e => e.Author)
                .WithMany()
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Candidacy> Candidacy { get; set; }
        public DbSet<Votes> Votes { get; set; }
        public DbSet<EventAttendant> EventAttendants { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<TypeOfEvent> TypeOfEvents { get; set; }
    }
}
