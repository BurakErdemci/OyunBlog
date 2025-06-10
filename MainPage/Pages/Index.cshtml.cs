using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.DTOs;
using BusinessLogic.Services;

namespace MainPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly INewsService _newsService;

        public List<NewsDto> News { get; set; } = new();

        public IndexModel(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task OnGetAsync()
        {
            News = await _newsService.GetLatestNewsAsync();
        }
    }
} 