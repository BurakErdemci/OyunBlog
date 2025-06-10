using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class BlogPost:BaseEntity
    {
      

        [Required]
        [MaxLength(200)]
        public required string  Title { get; set; }

        [Required]
        public required string Content { get; set; }

        [MaxLength(300)]
        public string? Summary { get; set; }

        [MaxLength(500)]
        public string? FeaturedImageUrl { get; set; }

        [MaxLength(200)]
        public string? Slug { get; set; }

        public int ViewCount { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsPublished { get; set; }

        public bool IsFeatured { get; set; }

        // Navigation Properties
        public int? GameId { get; set; } // Nullable - post oyun hakkında olmayabilir
        public virtual Game? Game { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
    }
}

