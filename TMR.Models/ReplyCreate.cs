using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMR.Models
{
    public class ReplyCreate
    {
        [Required] [MaxLength(5000, ErrorMessage ="Reply too long.")] public string Body { get; set; }
        public int PostID { get; set; }

        public ReplyCreate() { }
     public ReplyCreate(int id)
    {
            PostID = id;
    }
    }

}
