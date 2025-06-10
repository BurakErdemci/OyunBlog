namespace Core.Concretes.DTOs
{
    public class ForumTopicDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public int ReplyCount { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 