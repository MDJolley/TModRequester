using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMR.Data
{
    public class Post
    {
        [Key] public int ID { get; set; }
        [Required] public Guid UserID { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Body { get; set; }
        [Required] public DateTimeOffset TimePosted { get; set; }
        public DateTimeOffset? TimeEdited { get; set; }
        public int Votes { get; set; } = 0;
        public List<Guid> Voters { get; set; }
        public bool Solved { get; set; } = false;
    }
}
