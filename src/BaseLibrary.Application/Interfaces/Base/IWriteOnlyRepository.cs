using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Infrastructure.Data.Repositories.Base
{
    public interface IWriteOnlyRepository<TEntity> where TEntity : class
    {
        public Task AddAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(params object[] keyValues);
    }
}
