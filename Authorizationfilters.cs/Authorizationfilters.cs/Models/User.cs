using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Authorizationfilters.cs.Models
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}