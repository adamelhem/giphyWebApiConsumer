using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Request
{
    public class GiphyTrendingRequest : IGiphyRequest
    {
        private const string _url = @"https://api.giphy.com/v1/gifs/trending?api_key=ikitTARik6QXdfjX6K4sb2G3nqMxPMkG&limit=25&rating=g";
        public GiphyTrendingRequest()
        {
        }
        public string url => $"{_url}";
    }
}