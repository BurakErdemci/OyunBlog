namespace MainPage.Models
{
    public class BlogPostListModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Summary { get; set; }
        public string? FeaturedImageUrl { get; set; }
        public string? Slug { get; set; }
        public int ViewCount { get; set; }
        public bool IsPublished { get; set; }
        public string? GameTitle { get; set; }
    }
} 