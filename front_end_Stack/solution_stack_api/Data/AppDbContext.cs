using Microsoft.EntityFrameworkCore;
using solution_stack_shared.models;

namespace solution_stack_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.ID);
                entity.Property(o => o.Email).IsRequired();
                entity.Property(o => o.Name).IsRequired();
                entity.Property(o => o.Address).IsRequired();
            });
        }
    }
}
