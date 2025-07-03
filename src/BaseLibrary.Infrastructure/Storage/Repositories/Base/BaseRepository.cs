using BaseLibrary.Application.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace BaseLibrary.Infrastructure.Storage.Repositories.Base
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null in BaseRepo");
            _dbSet = context.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<TEntity?> GetByIdAsync(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            //SetAuditFields(entity, isUpdate: false);
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            var entity = await GetByIdAsync(keyValues);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues) != null;
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> QueryAsNoTracking()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }
    }
}