using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
   
    public class Review:BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string  ReviewerName { get; set; }

        [Required]
        public required string Content { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public bool IsApproved { get; set; }

        // Navigation Properties
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
