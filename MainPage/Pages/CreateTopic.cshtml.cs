using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.Entities;
using BusinessLogic.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MainPage.Pages
{
    [Authorize]
    public class CreateTopicModel : PageModel
    {
        private readonly ForumService _forumService;

        [BindProperty]
        public ForumTopic Topic { get; set; }

        public List<ForumCategory> Categories { get; set; } = new();
        public SelectList CategoryList { get; set; }

        public CreateTopicModel(ForumService forumService)
        {
            _forumService = forumService;
        }

        public async Task OnGetAsync()
        {
            Categories = await _forumService.GetAllCategoriesAsync();
            CategoryList = new SelectList(Categories, "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Categories = await _forumService.GetAllCategoriesAsync();
            CategoryList = new SelectList(Categories, "Id", "Name");

            if (!ModelState.IsValid)
                return Page();

            // Kullanıcı Id'sini ekle
            Topic.UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            await _forumService.CreateTopicAsync(Topic);
            return RedirectToPage("/Forum");
        }
    }
} 