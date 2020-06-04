using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMR.Data;

namespace TMR.Models
{
    public class ProfileDetail
    {
        public Pictures Picture { get; set; }
        public string BIO { get; set; }
        [MaxLength(20, ErrorMessage = "Username too long!")]
        [MinLength(3, ErrorMessage = "Username too short!")]
        public string UserName { get; set; }
    }
}