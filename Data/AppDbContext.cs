using Microsoft.EntityFrameworkCore;
using BaseLibrary.Data.Entities;
using BaseApiLibrary.TestObjects;

namespace BaseLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TestEntity> TestEntities { get; set; } = null;// Example DbSet for TestEntity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure entity properties and relationships here
            modelBuilder.Entity<TestEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TestProperty).HasPrecision(18, 2); // Example precision for a float property
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
