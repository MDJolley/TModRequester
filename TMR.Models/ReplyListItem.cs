using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;

namespace TMR.Models
{
    public class ReplyListItem
    {
        public int ID { get; set; }
        public Guid UserID { get; set; }
        public ProfileDetail ProfileDetail { get; set; }
        public string Body { get; set; }
        public int PostID { get; set; }
    }
}
