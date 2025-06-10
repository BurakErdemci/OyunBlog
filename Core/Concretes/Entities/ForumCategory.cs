using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.Entities
{
    public class ForumCategory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        // Konular
        public ICollection<ForumTopic> Topics { get; set; }
    }
} 