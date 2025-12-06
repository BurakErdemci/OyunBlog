using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Core.Concretes.DTOs; // DTO namespace'i
using Core.Concretes.Entities;
using BusinessLogic.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace MainPage.Pages
{
    public class TopicModel : PageModel
    {
        private readonly ForumService _forumService;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

       
        public ForumTopicDto Topic { get; set; }

        [BindProperty]
        public string ReplyContent { get; set; }

        public TopicModel(ForumService forumService)
        {
            _forumService = forumService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await _forumService.IncrementViewCountAsync(id);
            var topicEntity = await _forumService.GetTopicByIdAsync(id);

            if (topicEntity == null) return NotFound();

            Topic = new ForumTopicDto
            {
                Id = topicEntity.Id,
                Title = topicEntity.Title,
                Content = topicEntity.Content,
                CategoryName = topicEntity.Category?.Name ?? "Genel",
                UserName = topicEntity.User?.UserName ?? "Bilinmeyen Kullanýcý",
                ViewCount = topicEntity.ViewCount,
                ReplyCount = topicEntity.ReplyCount,
                CreatedAt = topicEntity.CreatedAt,
                Replies = topicEntity.Replies 
            };

            return Page();
        }

        public async Task<IActionResult> OnPostReplyAsync()
        {
            if (!User.Identity.IsAuthenticated) return Forbid();
            if (string.IsNullOrWhiteSpace(ReplyContent)) return await OnGetAsync(Id);

            var reply = new ForumReply
            {
                Content = ReplyContent, 
                TopicId = Id,
                UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
                CreatedAt = System.DateTime.Now
            };

            await _forumService.AddReplyAsync(reply);
            return RedirectToPage(new { id = Id });
        }
    }
}