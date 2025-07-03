namespace BaseLibrary.Application.Interfaces.Base
{
    public interface IBaseRepository<TEntity> : IReadOnlyRepository<TEntity>, IWriteOnlyRepository<TEntity> where TEntity : class
    {
    }
}