using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.Entities;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MainPage.Pages.Shared
{
    [Authorize(Roles = "Admin")]
    public class EditTopicModel : PageModel
    {
        private readonly ForumService _forumService;
        public EditTopicModel(ForumService forumService)
        {
            _forumService = forumService;
        }

        [BindProperty]
        public ForumTopic Topic { get; set; }
        public List<Core.Concretes.Entities.ForumCategory> Categories { get; set; } = new();
        public SelectList CategoryList { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Topic = await _forumService.GetTopicByIdAsync(id);
            if (Topic == null) return NotFound();
            Categories = await _forumService.GetAllCategoriesAsync();
            CategoryList = new SelectList(Categories, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Categories = await _forumService.GetAllCategoriesAsync();
            CategoryList = new SelectList(Categories, "Id", "Name");
            if (!ModelState.IsValid)
                return Page();
            await _forumService.UpdateTopicAsync(Topic);
            return RedirectToPage("/Forum");
        }
    }
} 