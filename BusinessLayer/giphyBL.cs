using DataAccessLayer;
using DTO.Response;
using System;

namespace BusinessLayer
{
    public class GiphyBL
    {
    public Task<IReturnObject<List<string>>> GetSearchWordImages(string searchWord)
        {
           var url = @"https://api.giphy.com/v1/gifs/search?api_key=ikitTARik6QXdfjX6K4sb2G3nqMxPMkG&q=" + word + @"&limit=25&offset=0&rating=g&lang=en";
            return await new WebAPIhandler().GetSearchWordImages(searchWord);
        }

        public Task<IReturnObject<List<string>>> GetTrendingImagesUrls()
        {
            throw new NotImplementedException();
        }

    }
}