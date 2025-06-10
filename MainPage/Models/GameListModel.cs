namespace MainPage.Models
{
    public class GameListModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
        public decimal Rating { get; set; }
        public int ViewCount { get; set; }
        public string? Description { get; set; }
        public string? DownloadUrl { get; set; }
        public string? WebPlayUrl { get; set; }
    }
} 