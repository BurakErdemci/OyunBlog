using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Devoloper:BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [MaxLength(500)]
        public string? Website { get; set; }

        [MaxLength(300)]
        public string? LogoUrl { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

      
        public virtual ICollection<Game>? Games { get; set; }
    }
}
