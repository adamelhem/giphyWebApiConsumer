using GifSearchAppMVC.APIdata;
using GifSearchAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace GifSearchAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _memoryCache = new MemoryCache(new MemoryCacheOptions() { });
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
        [HttpPost]
        public async Task<IActionResult> GetGifUrls(string word)
        {
            return await GetTrending(word);
        }

        private async Task<IActionResult> GetTrending(string word)
        {
                if ( word == null)
            {
                word = "";
            }

                var cacheRec = _memoryCache.Get(word);
                
                if (cacheRec != null)
                {
                    return Ok(cacheRec as String[]);
                }
                 
            var url = @"https://api.giphy.com/v1/gifs/trending?api_key=ikitTARik6QXdfjX6K4sb2G3nqMxPMkG&limit=25&rating=g";

            if (!string.IsNullOrWhiteSpace(word))
            {
                url = @"https://api.giphy.com/v1/gifs/search?api_key=ikitTARik6QXdfjX6K4sb2G3nqMxPMkG&q=" + word + @"&limit=25&offset=0&rating=g&lang=en";
            }

            return await Task.Run(async () =>
            {
                var response = GetAPIdataResponse<TrendingResponse>(url);
                var images = response?.data?.Select(x => x.images?.original?.url);
                if (images?.Any() == true)
                {
                    _memoryCache.Set(word, images, DateTime.Now.AddMinutes(3));
                }
                return Ok(images);
            });

        }

        private static T GetAPIdataResponse<T>(string url)
        {
            var jsonResponse = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                jsonResponse = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

    }
}