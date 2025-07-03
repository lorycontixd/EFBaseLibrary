using BaseLibrary.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BaseLibrary.Infrastructure.Data.DbContexts
{
    public abstract class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        private void UpdateAuditEntities()
        {
            // All entities that inherit from AuditableEntity and that are being tracked by the ChangeTracker
            var entries = ChangeTracker.Entries<AuditableEntity>();

            foreach (var entry in entries)
            {
                // If the entity is being added, set its CreatedAt and ModifiedAt timestamps.
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                // If the entity is being modified, update its ModifiedAt timestamp.
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}
