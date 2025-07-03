using BaseLibrary.Application.DTOs.Base;
using BaseLibrary.Core.Entities.Base;

namespace BaseLibrary.Application.Interfaces
{
    public interface IBaseRepository<TEntity, TDto> : IReadOnlyRepository<TEntity, TDto>, IWriteOnlyRepository<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
    }
}