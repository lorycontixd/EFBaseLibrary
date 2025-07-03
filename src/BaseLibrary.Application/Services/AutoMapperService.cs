using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Application.Services
{
    public class AutoMapperService
    {
        private readonly IMapper _mapper;

        public AutoMapperService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper cannot be null in AutoMapperService");
        }

        public TDestination Map<TDestination>(object source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source object cannot be null in AutoMapperService");
            }
            return _mapper.Map<TDestination>(source);
        }
        public ISourceToDestinationNameMapper Map<TSource, TDestination>(TSource source)
        {
            throw new NotImplementedException("This method is not implemented in AutoMapperService. Use Map<TDestination>(object source) instead.");
        }
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return _mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
        }

        public async Task<TDestination> MapAsync<TDestination>(object source)
        {
            return await Task.FromResult(_mapper.Map<TDestination>(source));
        }

        public async Task<IEnumerable<TDestination>> MapAsync<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source));
        }
    }
}
