using AutoMapper;
using DO;
using DO.Response;

namespace DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GiphyResponse, TrendingJsonResponse>(MemberList.None)
                .ForMember(dest => dest, o => o.MapFrom(src => src))
                .ReverseMap();
        }
    }
}