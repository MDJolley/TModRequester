using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;

namespace TMR.Models
{
    public class ReplyDetail
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string Body { get; set; }
        public ProfileDetail ProfileDetail { get; set; }
        public DateTimeOffset TimePosted { get; set; }
        public DateTimeOffset? TimeEdited { get; set; }
        public bool Solution { get; set; }
        public int PostID { get; set; }
    }
}
