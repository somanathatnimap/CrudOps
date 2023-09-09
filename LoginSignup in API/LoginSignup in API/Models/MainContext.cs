using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginSignup_in_API.Models
{
    public class MainContext:DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<Catagories> catagories { get; set; }
    }
}