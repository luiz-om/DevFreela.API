using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Models
{
    public class CreateProjectCommentInputModel
    {
        public string NoContent{ get; set; }
        public int IdProject { get; set; } 
        public int IdUser { get; set; }
    }
}