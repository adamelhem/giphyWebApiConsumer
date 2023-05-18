using AutoMapper;
using DO;
using DO.Response;

namespace DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TrendingJsonResponse, GiphyResponse>(MemberList.None)
                .ForMember(dest => dest, o => o.MapFrom<IEnumerable<string>>(src => extractImagesUrl(src)))
                .ReverseMap();
        }

        private IEnumerable<string?>?extractImagesUrl(TrendingJsonResponse src)
            => src.data?.Select(x => x.images?.original?.url);
    
    }
}