using AutoMapper;
using DataAccessLayer;
using DO;
using DO.Request;
using DO.Response;
using DTO.Response;

namespace BusinessLayer
{
    public class GiphyBL : IGiphyBL
    {
        private readonly IMapper _mapper;
        private readonly IWebAPIhandler _webAPIhandler;

        public GiphyBL(IMapper mapper, IWebAPIhandler webAPIhandler)
        {
            _mapper = mapper;
            _webAPIhandler = webAPIhandler;
        }

        public async Task<IReturnObject<List<string>>> GetSearchWordImages(string searchWord)
        {
            var result = await _webAPIhandler.GetAPIdataResponse<TrendingJsonResponse>(new GiphySearchRequest(searchWord));
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

            var result = await _webAPIhandler.GetAPIdataResponse<TrendingJsonResponse>(new GiphyTrendingRequest());
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