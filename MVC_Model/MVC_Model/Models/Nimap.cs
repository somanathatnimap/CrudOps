using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Model.Models
{
    public class Nimap
    {
        [Required]
        public int name { get; set; }
        [SomaValidation]
        public int address { get; set; }
    }
}