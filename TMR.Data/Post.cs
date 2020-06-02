using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMR.Data
{
    public class Post
    {
        private static readonly List<Guid> voters = new List<Guid>();
        [Key] public int ID { get; set; }
        [Required] public Guid UserID { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Body { get; set; }
        [Required] public DateTimeOffset TimePosted { get; set; }
        [ForeignKey(nameof(UserID))] public virtual Profile Profile { get; set; }
        public DateTimeOffset? TimeEdited { get; set; }
        public List<Guid> Voters { get; set; } = voters;
        public int Votes { get; set; } = 0;
        public bool Solved { get; set; } = false;
    }
}
