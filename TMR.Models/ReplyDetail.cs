using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset TimePosted { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? TimeEdited { get; set; }
        public bool Solution { get; set; }
        public int PostID { get; set; }
    }
}
