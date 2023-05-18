using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO.Request
{
    public class GiphySearchRequest : IGiphyRequest
    {
        private const string _reqPart1 = @"https://api.giphy.com/v1/gifs/search?api_key=ikitTARik6QXdfjX6K4sb2G3nqMxPMkG&q=";
        private const string _reqPart2 = @"&limit=25&offset=0&rating=g&lang=en";
        public GiphySearchRequest(string searchKeyWord)
        {
            this.searchKeyWord = searchKeyWord;
        }
        public string searchKeyWord { set; get; }
        public string url => $"{_reqPart1}{searchKeyWord}{_reqPart2}";
    }
}
