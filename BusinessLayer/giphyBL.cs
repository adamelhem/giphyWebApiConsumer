using AutoMapper;
using DataAccessLayer;
using DO;
using DO.Request;
using DO.Response;
using DTO.Response;

namespace BusinessLayer
{
    public class GiphyBL
    {
        private readonly IMapper _mapper;
        public GiphyBL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IReturnObject<List<string>>> GetSearchWordImages(string searchWord)
        {
            var result = await new WebAPIhandler().GetAPIdataResponse<TrendingJsonResponse>(new GiphySearchRequest(searchWord));
            if (result != null)
            {
                var failResult = new ReturnObject<List<string>>();
                return failResult.setError();
            }
            var success = new ReturnObject<List<string>>();
            var dataResult = _mapper.Map<GiphyResponse>(result);
            return success.setSuccess(dataResult.imagesUrls);
        }

        public async Task<IReturnObject<List<string>>> GetTrendingImagesUrls()
        {

            var result = await new WebAPIhandler().GetAPIdataResponse<TrendingJsonResponse>(new GiphyTrendingRequest());
            if (result != null)
            {
                var failResult = new ReturnObject<List<string>>();
                return failResult.setError();
            }
            var success = new ReturnObject<List<string>>();
            var dataResult = _mapper.Map<GiphyResponse>(result);
            return success.setSuccess(dataResult.imagesUrls);
        }

    }
}