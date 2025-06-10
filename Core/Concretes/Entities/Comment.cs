using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Comment:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string  Name { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        public required string Content { get; set; }

        public bool IsApproved { get; set; }

        public int? ParentCommentId { get; set; } 
        public virtual Comment? ParentComment { get; set; }

       
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }

        public virtual ICollection<Comment>? Replies { get; set; }
    }
}
