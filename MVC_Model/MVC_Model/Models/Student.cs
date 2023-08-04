using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Model.Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public StudentAddress Address { get; set; }
    }
}