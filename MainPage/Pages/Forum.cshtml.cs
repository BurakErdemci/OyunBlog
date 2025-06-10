using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.DTOs;
using BusinessLogic.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace MainPage.Pages
{
    public class ForumModel : PageModel
    {
        private readonly ForumService _forumService;
        public List<ForumTopicDto> Topics { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public const int PageSize = 5;

        public ForumModel(ForumService forumService)
        {
            _forumService = forumService;
        }

        public async Task OnGetAsync(string q, [FromQuery] int page = 1)
        {
            System.Diagnostics.Debug.WriteLine($"Current page: {page}");
            var allTopics = await _forumService.GetAllTopicsDtoAsync();
            if (!string.IsNullOrWhiteSpace(q))
            {
                allTopics = allTopics
                    .Where(t => t.Title != null && t.Title.Contains(q, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            int totalCount = allTopics.Count;
            TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);
            CurrentPage = page;

            Topics = allTopics
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _forumService.DeleteTopicAsync(id);
            return RedirectToPage("/Forum");
        }
    }
} 