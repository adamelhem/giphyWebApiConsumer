using AutoMapper;
using BusinessLayer;
using DataAccessLayer;
using DO;
using GifSearchAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace GifSearchAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _autoMapper;
        private readonly IGiphyBL _giphyBL;

        public HomeController(IGiphyBL giphyBL, ILogger<HomeController> logger, IMemoryCache memoryCache, IMapper autoMapper)
        {
            _giphyBL = giphyBL;
            _logger = logger;
            _memoryCache = memoryCache;
            _autoMapper = autoMapper;
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
            if (string.IsNullOrWhiteSpace(word))
            {
                return BadRequest();
            }

            var cacheKey = $"{nameof(HomeController)}{nameof(GetGifUrls)}{word}";
            var cacheRec = _memoryCache.Get(cacheKey);

            if (cacheRec != null)
            {
                return Ok(cacheRec);
            }

            var result = await _giphyBL.GetTrendingImagesUrls();
            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            var response = Ok(result);
            if (result?.data?.Any() == true)
            {
                _memoryCache.Set(word, response, DateTime.Now.AddMinutes(3));
            }

            return response;
        }

        [HttpPost]
        [ResponseCache(Duration = 5, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> GetTrendingUrls()
        {
            var result = await _giphyBL.GetTrendingImagesUrls();
            if(!result.IsSuccess)
            {
                return BadRequest();
            }
            return Ok(result);
        }

    }
}