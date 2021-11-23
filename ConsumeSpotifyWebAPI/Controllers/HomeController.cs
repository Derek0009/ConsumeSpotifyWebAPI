using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumeSpotifyWebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;

        public HomeController(ISpotifyAccountService spotifyAccountService, IConfiguration configuration)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);
            }

            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            return View();
        }
    }
}
