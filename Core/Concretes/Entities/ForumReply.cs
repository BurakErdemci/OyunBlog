using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities
{
    public class ForumReply
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Kullanıcı ilişkisi
        public string? UserId { get; set; }
        public IdentityUser User { get; set; }

        // Konu ilişkisi
        public int TopicId { get; set; }
        public ForumTopic Topic { get; set; }
    }
} 