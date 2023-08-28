using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_CRUD.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}