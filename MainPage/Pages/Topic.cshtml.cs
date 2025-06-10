using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.Entities;
using BusinessLogic.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MainPage.Pages
{
    public class TopicModel : PageModel
    {
        private readonly ForumService _forumService;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public ForumTopic Topic { get; set; }

        [BindProperty]
        public string Content { get; set; }

        public TopicModel(ForumService forumService)
        {
            _forumService = forumService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await _forumService.IncrementViewCountAsync(id);
            Topic = await _forumService.GetTopicByIdAsync(id);
            if (Topic == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return Forbid();
            if (string.IsNullOrWhiteSpace(Content))
                return await OnGetAsync(Id);

            var reply = new ForumReply
            {
                Content = Content,
                TopicId = Id,
                UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
            };
            await _forumService.AddReplyAsync(reply);
            return RedirectToPage(new { id = Id });
        }
    }
} 