namespace MainPage.Models
{
    public class CategoryListModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
    }
} 