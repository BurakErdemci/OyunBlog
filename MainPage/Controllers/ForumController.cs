using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Services;
using Core.Concretes.Entities;
using MainPage.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;

namespace MainPage.Controllers
{
    public class ForumController : Controller
    {
        private readonly ForumService _forumService;
        private readonly UserManager<IdentityUser> _userManager;

        public ForumController(ForumService forumService, UserManager<IdentityUser> userManager)
        {
            _forumService = forumService;
            _userManager = userManager;
        }

       
        public async Task<IActionResult> Index()
        {
            var topics = await _forumService.GetAllTopicsAsync();
            if (topics == null || !topics.Any())
            {
                topics = new List<ForumTopic>();
            }
            return View(topics);
        }

    
        public async Task<IActionResult> Topic(int id)
        {
            var topic = await _forumService.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            await _forumService.IncrementViewCountAsync(id);
            return View(topic);
        }

      
        [Authorize]
        public async Task<IActionResult> CreateTopic()
        {
            ViewBag.Categories = await _forumService.GetAllCategoriesAsync();
            return View();
        }

     
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTopic(ForumTopic topic)
        {
            if (ModelState.IsValid)
            {
                topic.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _forumService.CreateTopicAsync(topic);
                return RedirectToAction(nameof(Topic), new { id = topic.Id });
            }
            ViewBag.Categories = await _forumService.GetAllCategoriesAsync();
            return View(topic);
        }

      
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReply(ForumReply reply)
        {
            if (ModelState.IsValid)
            {
                reply.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                await _forumService.AddReplyAsync(reply);
                return RedirectToAction(nameof(Topic), new { id = reply.TopicId });
            }
            return RedirectToAction(nameof(Topic), new { id = reply.TopicId });
        }
    }
} 