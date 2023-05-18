using AutoMapper;

namespace DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            //CreateMap<I, IicVM>()
            //    .ForMember(dest => dest.DepartmentName, o => o.MapFrom(src => src.Department.Name))
            //    .ForMember(dest => dest.PortfolioTypeName, o => o.MapFrom(src => src.PortfolioType.Name));
            //    .i
            //    .ReverseMap();
        }
    }
}