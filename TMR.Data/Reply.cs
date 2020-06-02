using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;

namespace TMR.Data
{
    public class Reply
    {
        [Key] public int ID { get; set; }
        [Required] public string Body { get; set; }
        [Required] public Guid UserID { get; set; }
        [Required] public DateTimeOffset TimePosted { get; set; }
        [Required] public int PostID { get; set; }
        public DateTimeOffset? TimeEdited { get; set; }
        public bool Solution { get; set; } = false;


        [ForeignKey(nameof(UserID))]
        public virtual Profile Profile { get; set; }



      
    }
}
