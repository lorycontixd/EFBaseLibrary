using BaseLibrary.Application.DTOs.Base;
using BaseLibrary.Application.Interfaces;
using BaseLibrary.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace BaseLibrary.Infrastructure.Storage.Repositories.Base
{
    public class BaseRepository<TContext, TEntity, TDto> : IBaseRepository<TEntity, TDto>
        where TContext : DbContext
        where TEntity : class, IEntity
        where TDto : class, IDto
    {
        protected readonly TContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IAutoMapperService _mapper;

        public BaseRepository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context cannot be null in BaseRepo");
            _dbSet = context.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }
        public virtual async Task<TDto?> GetByIdAsync(params object[] keyValues)
        {
            var entity = await _context.Set<TEntity>().FindAsync(keyValues);
            return entity == null ? null : _mapper.Map<TDto>(entity);
        }
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            //SetAuditInfo(entity, false);

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);

        }
        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = await _dbSet.FindAsync(dto.Id);
            if (entity == null)
                throw new ArgumentException($"Entity with id {dto.Id} not found");

            _mapper.Map(dto, entity);
            //SetAuditInfo(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<TDto>(entity);
        }
        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            var dto = await GetByIdAsync(keyValues);
            var entity = _mapper.Map<TEntity>(dto);
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

        public IQueryable<TDto> Query()
        {
            var queriable = _dbSet.AsQueryable();
            return queriable.Select(entity => _mapper.Map<TDto>(entity)).AsQueryable();
        }

        public IQueryable<TDto> QueryAsNoTracking()
        {
            var queriable = _dbSet.AsNoTracking().AsQueryable();
            return queriable.Select(entity => _mapper.Map<TDto>(entity)).AsQueryable();
        }
    }
}