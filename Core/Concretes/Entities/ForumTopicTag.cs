namespace Core.Concretes.Entities
{
    public class ForumTopicTag
    {
        public int ForumTopicId { get; set; }
        public ForumTopic ForumTopic { get; set; }

        public int ForumTagId { get; set; }
        public ForumTag ForumTag { get; set; }
    }
} 