using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMR.Models
{
    public class PostCreate
    {
        [Required] [MinLength(4, ErrorMessage ="Please enter at least 4 characters.")] [MaxLength(100, ErrorMessage ="Post title too long.")]
        public string Title { get; set; }
        [Required] [MaxLength(10000, ErrorMessage ="Post body too long.")]
        public string Body { get; set; }
    }
}
