using System.ComponentModel.DataAnnotations;

namespace MainPage.Models
{
    public class BlogPostFormModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Content { get; set; } = null!;

        [MaxLength(300)]
        public string? Summary { get; set; }

        [MaxLength(500)]
        public string? FeaturedImageUrl { get; set; }

        [MaxLength(200)]
        public string? Slug { get; set; }

        public int? GameId { get; set; }
        public bool IsPublished { get; set; }
        public bool IsFeatured { get; set; }
    }
} 