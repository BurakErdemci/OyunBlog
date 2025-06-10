using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.DTOs;
using BusinessLogic.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MainPage.Pages
{
    public class IndirimlerModel : PageModel
    {
        private readonly IDealService _dealService;
        // public List<DealDto> Deals { get; set; } = new();
        public List<DealDto> SteamDeals { get; set; } = new();
        public List<DealDto> EpicDeals { get; set; } = new();

        public IndirimlerModel(IDealService dealService)
        {
            _dealService = dealService;
        }

        public async Task OnGetAsync()
        {
            SteamDeals = await _dealService.GetSteamDealsAsync();
            EpicDeals = await _dealService.GetEpicDealsAsync();
        }
    }
} 