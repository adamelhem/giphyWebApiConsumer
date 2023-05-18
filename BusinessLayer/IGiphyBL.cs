using DTO.Response;

namespace BusinessLayer
{
    public interface IGiphyBL
    {
        Task<IReturnObject<List<string>>> GetSearchWordImages(string searchWord);
        Task<IReturnObject<List<string>>> GetTrendingImagesUrls();
    }
}