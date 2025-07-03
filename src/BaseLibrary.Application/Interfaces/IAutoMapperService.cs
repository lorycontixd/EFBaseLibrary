namespace BaseLibrary.Application.Interfaces
{
    /// <summary>
    /// Service interface for AutoMapper operations, allowing mapping between source and destination types.
    /// </summary>
    public interface IAutoMapperService
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);
        Task<TDestination> MapAsync<TDestination>(object source);
        Task<IEnumerable<TDestination>> MapAsync<TSource, TDestination>(IEnumerable<TSource> source);
    }
}
