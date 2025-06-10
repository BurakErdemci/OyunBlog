using Core.Concretes.DTOs;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IDealService
    {
        Task<List<DealDto>> GetSteamDealsAsync();
        Task<List<DealDto>> GetEpicDealsAsync();
        Task<List<DealDto>> GetAllDealsAsync();
    }

    public class DealService : IDealService
    {
        private readonly HttpClient _httpClient;
        public DealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DealDto>> GetSteamDealsAsync()
        {
            var url = "https://store.steampowered.com/api/featuredcategories";
            var response = await _httpClient.GetStringAsync(url);
            using var doc = JsonDocument.Parse(response);
            var deals = new List<DealDto>();
            var specials = doc.RootElement.GetProperty("specials").GetProperty("items");
            foreach (var item in specials.EnumerateArray())
            {
                deals.Add(new DealDto
                {
                    Id = item.GetProperty("id").GetInt32(),
                    Name = item.GetProperty("name").GetString() ?? "",
                    DiscountPercent = item.GetProperty("discount_percent").GetInt32(),
                    OriginalPrice = item.GetProperty("original_price").GetInt32(),
                    FinalPrice = item.GetProperty("final_price").GetInt32(),
                    LargeCapsuleImage = item.GetProperty("large_capsule_image").GetString() ?? "",
                    HeaderImage = item.GetProperty("header_image").GetString() ?? "",
                    Platform = "Steam"
                });
            }
            return deals;
        }

        public async Task<List<DealDto>> GetEpicDealsAsync()
        {
            var url = "https://store-site-backend-static.ak.epicgames.com/freeGamesPromotions?locale=tr&country=TR&allowCountries=TR";
            var response = await _httpClient.GetStringAsync(url);
            using var doc = JsonDocument.Parse(response);
            var deals = new List<DealDto>();
            if (!doc.RootElement.TryGetProperty("data", out var data) ||
                !data.TryGetProperty("Catalog", out var catalog) ||
                !catalog.TryGetProperty("searchStore", out var searchStore) ||
                !searchStore.TryGetProperty("elements", out var elements) ||
                elements.ValueKind != JsonValueKind.Array)
            {
                return deals;
            }
            foreach (var item in elements.EnumerateArray())
            {
                // Only show games with a current free promotion
                if (!item.TryGetProperty("promotions", out var promotions) ||
                    promotions.ValueKind != JsonValueKind.Object ||
                    !promotions.TryGetProperty("promotionalOffers", out var promoOffers) ||
                    promoOffers.ValueKind != JsonValueKind.Array ||
                    promoOffers.GetArrayLength() == 0 ||
                    promoOffers[0].ValueKind != JsonValueKind.Object ||
                    !promoOffers[0].TryGetProperty("promotionalOffers", out var offersArr) ||
                    offersArr.ValueKind != JsonValueKind.Array ||
                    offersArr.GetArrayLength() == 0)
                {
                    continue;
                }
                var title = item.TryGetProperty("title", out var titleProp) && titleProp.ValueKind == JsonValueKind.String ? titleProp.GetString() : "";
                string image = null;
                if (item.TryGetProperty("keyImages", out var images) && images.ValueKind == JsonValueKind.Array)
                {
                    foreach (var img in images.EnumerateArray())
                    {
                        if (img.TryGetProperty("type", out var typeProp) && typeProp.ValueKind == JsonValueKind.String && typeProp.GetString() == "OfferImageWide" &&
                            img.TryGetProperty("url", out var urlProp) && urlProp.ValueKind == JsonValueKind.String)
                        {
                            image = urlProp.GetString();
                            break;
                        }
                    }
                    if (image == null && images.GetArrayLength() > 0)
                    {
                        var firstImg = images[0];
                        if (firstImg.TryGetProperty("url", out var urlProp) && urlProp.ValueKind == JsonValueKind.String)
                            image = urlProp.GetString();
                    }
                }
                var productSlug = item.TryGetProperty("productSlug", out var slugProp) && slugProp.ValueKind == JsonValueKind.String ? slugProp.GetString() : null;
                var urlSlug = item.TryGetProperty("urlSlug", out var urlSlugProp) && urlSlugProp.ValueKind == JsonValueKind.String ? urlSlugProp.GetString() : null;
                var gameUrl = productSlug != null ? $"https://store.epicgames.com/tr/p/{productSlug}" :
                              urlSlug != null ? $"https://store.epicgames.com/tr/p/{urlSlug}" :
                              "https://store.epicgames.com/";
                deals.Add(new DealDto
                {
                    Id = 0,
                    Name = title,
                    DiscountPercent = 100,
                    OriginalPrice = 0,
                    FinalPrice = 0,
                    LargeCapsuleImage = image ?? "",
                    HeaderImage = image ?? "",
                    Platform = "Epic Games",
                    GameUrl = gameUrl
                });
            }
            return deals;
        }

        public async Task<List<DealDto>> GetAllDealsAsync()
        {
            var steamDeals = await GetSteamDealsAsync();
            var epicDeals = await GetEpicDealsAsync();
            var all = new List<DealDto>();
            all.AddRange(steamDeals);
            all.AddRange(epicDeals);
            return all;
        }
    }
} 