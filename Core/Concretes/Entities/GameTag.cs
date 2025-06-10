using Core.Abstracts.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class GameTag:BaseEntity
    {
       
        public int GameId { get; set; }
        public virtual Game? Game { get; set; }
        
        public int TagId { get; set; }
        public  virtual Tag? Tag { get; set; }
    }
}
