using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [MaxLength(200)]
        public string? IconUrl { get; set; }

        // Navigation Properties
        public virtual ICollection<Game>? Games { get; set; }
    }
}
