using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Core.Concretes.Entities
{
    public class ForumTopic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int ViewCount { get; set; }
        public int ReplyCount { get; set; }

        // Kullanıcı ilişkisi
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        // Kategori ilişkisi
        [Required(ErrorMessage = "Kategori seçiniz.")]
        [Range(1, int.MaxValue, ErrorMessage = "Kategori seçiniz.")]
        public int? CategoryId { get; set; }
        public ForumCategory? Category { get; set; }

        // Yorumlar
        public ICollection<ForumReply>? Replies { get; set; }

        // Etiketler
        public ICollection<ForumTopicTag>? ForumTopicTags { get; set; }
    }
} 