using DTO.Response;

namespace BusinessLayer
{
    public class giphyBL
    {
        public IReturnObject<List<string>> getImagesUrls(string searchWord)
        {
            throw new NotImplementedException();
        }

        public IReturnObject<List<string>> getTrendingImagesUrls()
        {
            throw  new NotFiniteNumberException();
        }
    }
}