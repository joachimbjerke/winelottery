using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.DataContext
{
    public class LotteryDbContext : DbContext
    {
        public LotteryDbContext(DbContextOptions<LotteryDbContext> context)
            : base(context)
        {
        }

        public DbSet<Lottery> Lottery { get; set;}
        public DbSet<User> User { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                
        }
    }
}
