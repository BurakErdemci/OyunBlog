using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Concretes.Entities;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Core.Concretes.DTOs;

namespace BusinessLogic.Services
{
    public class ForumService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ForumService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Konu işlemleri
        public async Task<List<ForumTopic>> GetAllTopicsAsync()
        {
            return await _context.ForumTopics
                .Include(t => t.User)
                .Include(t => t.Category)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<ForumTopic> GetTopicByIdAsync(int id)
        {
            var topic = await _context.ForumTopics
                .Include(t => t.User)
                .Include(t => t.Category)
                .Include(t => t.Replies)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (topic == null)
                return null;
            topic.Replies = topic.Replies ?? new List<ForumReply>();
            return topic;
        }

        public async Task<ForumTopic> CreateTopicAsync(ForumTopic topic)
        {
            topic.CreatedAt = DateTime.UtcNow;
            topic.ViewCount = 0;
            topic.ReplyCount = 0;

            _context.ForumTopics.Add(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task IncrementViewCountAsync(int topicId)
        {
            var topic = await _context.ForumTopics.FindAsync(topicId);
            if (topic != null)
            {
                topic.ViewCount++;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ForumReply> AddReplyAsync(ForumReply reply)
        {
            reply.CreatedAt = DateTime.UtcNow;

            _context.ForumReplies.Add(reply);

            // Konunun yanıt sayısını artır
            var topic = await _context.ForumTopics.FindAsync(reply.TopicId);
            if (topic != null)
            {
                topic.ReplyCount++;
            }

            await _context.SaveChangesAsync();
            return reply;
        }

        public async Task<List<ForumCategory>> GetAllCategoriesAsync()
        {
            return await _context.ForumCategories
                .Include(c => c.Topics)
                .ToListAsync();
        }

        public async Task<ForumCategory> CreateCategoryAsync(ForumCategory category)
        {
            _context.ForumCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // DTO ile forum konularını döndür
        public async Task<List<ForumTopicDto>> GetAllTopicsDtoAsync()
        {
            var topics = await _context.ForumTopics
                .Include(t => t.User)
                .Include(t => t.Category)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            return _mapper.Map<List<ForumTopicDto>>(topics);
        }

        public async Task UpdateTopicAsync(ForumTopic updatedTopic)
        {
            var topic = await _context.ForumTopics.FindAsync(updatedTopic.Id);
            if (topic != null)
            {
                topic.Title = updatedTopic.Title;
                topic.Content = updatedTopic.Content;
                topic.CategoryId = updatedTopic.CategoryId;
                topic.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTopicAsync(int id)
        {
            var topic = await _context.ForumTopics.FindAsync(id);
            if (topic != null)
            {
                _context.ForumTopics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }
    }
} 