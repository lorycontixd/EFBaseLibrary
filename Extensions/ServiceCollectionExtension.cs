using BaseLibrary.Data.Repo.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IWriteOnlyRepository<>), typeof(BaseRepository<,>));

            return services;
        }
    }
}
