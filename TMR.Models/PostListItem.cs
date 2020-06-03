using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;

namespace TMR.Models
{
    public class PostListItem
    {
        
        public string Title { get; set; }
        public Guid UserID { get; set; }
        public int PostID { get; set; }
        public ProfileDetail Profile { get; set; }
        public int Votes { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset TimePosted { get; set; }
    }
}
