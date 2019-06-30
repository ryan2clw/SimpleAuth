using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BingoNumber> BingoNumbers { get; set; }
        public DbSet<BingoGame> BingoGames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BingoNumber>()
                .HasOne(g => g.BingoGame)
                .WithMany(n => n.Numbers)
                .HasForeignKey(g => g.BingoGameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}