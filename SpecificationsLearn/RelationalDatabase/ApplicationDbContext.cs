using Microsoft.EntityFrameworkCore;
using SpecificationsLearn.Models;

namespace SpecificationsLearn.RelationalDatabase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Human> Humen { get; set; }
        public DbSet<Item> Items { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Human>()
                .HasMany(h => h.Items)
                .WithOne(i => i.Human)
                .HasForeignKey(i => i.HumanId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
