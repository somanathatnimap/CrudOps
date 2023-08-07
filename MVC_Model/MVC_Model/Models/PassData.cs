using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Model.Models
{
    public class PassData
    {
        [Required(ErrorMessage ="Plese Enter your first name")]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Range(20,100)]
        public int age { get; set; }
    }
}