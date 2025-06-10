using System.ComponentModel.DataAnnotations;

namespace MainPage.Models
{
    public class CategoryFormModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(300)]
        public string? Description { get; set; }

        [MaxLength(200)]
        public string? IconUrl { get; set; }
    }
} 