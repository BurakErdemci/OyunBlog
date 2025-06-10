using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class SystemSettings:BaseEntity
    {
      

        [Required]
        [MaxLength(100)]
        public required string Key { get; set; }

        public string? Value { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}

