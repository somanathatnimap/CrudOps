using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginSignup_in_API.Models
{
    public class Catagories
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string catagory_name { get; set; }
        [Required]
        public string catagory_desc { get; set; }
    }
}