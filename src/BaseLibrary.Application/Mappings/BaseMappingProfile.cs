using AutoMapper;
using BaseLibrary.Application.DTOs.Base;
using BaseLibrary.Core.Entities.Base;

namespace BaseLibrary.Application.Mappings
{
    public abstract class BaseMappingProfile : Profile
    {
        protected BaseMappingProfile()
        {
            // Creates base mapping with inheritance support.
            // CreateMap tells AutoMapper to map BaseEntity to BaseDto and all derived types.
            // IncludeAllDerived ensures that all derived classes of BaseEntity are also mapped to their corresponding DTOs.
            // ReverseMap allows for mapping back from DTOs to entities.
            CreateMap<BaseEntity, BaseDto>().IncludeAllDerived().ReverseMap();
        }
    }
}
