using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Core.Abstracts.BaseModels;

namespace Core.Concretes.Entities
{
    public class Game : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        public string? DetailedDescription { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        [MaxLength(500)]
        public string? ThumbnailUrl { get; set; }

        [MaxLength(500)]
        public string? DownloadUrl { get; set; }

        [MaxLength(500)]
        public string? WebPlayUrl { get; set; }

        [Column(TypeName = "decimal(3,2)")]
        public decimal Rating { get; set; }

        public int ViewCount { get; set; }

        public int DownloadCount { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsWebGame { get; set; }

        public bool IsDownloadable { get; set; }

        
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public int DeveloperId { get; set; }
        public virtual Devoloper? Developer { get; set; }

        public virtual ICollection<GameTag>? GameTags { get; set; }
        public virtual ICollection<GameScreenshot>? Screenshots { get; set; }
        public  virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
        
}
