using Microsoft.Extensions.DependencyInjection;

namespace BaseLibrary.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}
