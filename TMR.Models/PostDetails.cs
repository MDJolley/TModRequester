using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMR.Models
{
    public class PostDetail
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ProfileDetail Profile { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset TimePosted { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? TimeEdited { get; set; }
        public int Votes { get; set; } = 0;
        public List<Guid> Voters { get; set; }
        public bool Solved { get; set; } = false;
    }
}
