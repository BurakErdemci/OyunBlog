using Microsoft.AspNetCore.Mvc.RazorPages;
using MainPage.Models;
using Core.Abstracts.IServices;

namespace MainPage.Pages
{
    public class OyunlarModel : PageModel
    {
        private readonly IGameService _gameService;

        public List<GameListModel> Games { get; set; } = new();

        public OyunlarModel(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task OnGetAsync()
        {
            var games = await _gameService.GetAllAsync();
            Games = games.Select(g => new GameListModel
            {
                Id = g.Id,
                Title = g.Title,
                ImageUrl = g.ImageUrl,
                CategoryName = g.Category?.Name,
                Rating = g.Rating,
                ViewCount = g.ViewCount,
                Description = g.Description,
                DownloadUrl = g.DownloadUrl,
                WebPlayUrl = g.WebPlayUrl
            }).ToList();
        }
    }
} 