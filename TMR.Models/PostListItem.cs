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
        public int PostID { get; set; }

        [Display(Name="Date of Post")]
        public int Votes { get; set; }
        public DateTimeOffset TimePosted { get; set; }
    }
}
