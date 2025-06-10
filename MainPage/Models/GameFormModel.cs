using System.ComponentModel.DataAnnotations;

namespace MainPage.Models
{
    public class GameFormModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public decimal Rating { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsWebGame { get; set; }
        public bool IsDownloadable { get; set; }
    }
} 