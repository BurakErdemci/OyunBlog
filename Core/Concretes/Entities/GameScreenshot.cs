using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class GameScreenshot:BaseEntity
    {
        [Required]
        [MaxLength(500)]
        public required string ImageUrl { get; set; }

        [MaxLength(200)]
        public string? Alt { get; set; }

        public int Order { get; set; }

        
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
