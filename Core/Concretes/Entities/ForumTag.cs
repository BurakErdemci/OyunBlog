using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Entities
{
    public class ForumTag
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<ForumTopicTag> ForumTopicTags { get; set; }
    }
} 