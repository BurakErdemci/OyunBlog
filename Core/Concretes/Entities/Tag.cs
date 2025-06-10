using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Tag:BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [MaxLength(20)]
        public string? ColorCode { get; set; }
        
        public virtual ICollection<GameTag>? GameTags { get; set; }
    }
}
