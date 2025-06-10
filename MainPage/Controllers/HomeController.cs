using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstracts.IServices;
using MainPage.Models;

namespace MainPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _gameService;

        public HomeController(ILogger<HomeController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllAsync();
            var model = games.Select(g => new GameListModel
            {
                Id = g.Id,
                Title = g.Title,
                ImageUrl = g.ImageUrl,
                CategoryName = g.Category?.Name,
                Rating = g.Rating,
                ViewCount = g.ViewCount
            }).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // ErrorViewModel oluşturulursa buraya eklenebilir
            return View(/* new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } */);
        }
    }
} 