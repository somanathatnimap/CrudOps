using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authorizationfilters.cs.Models
{
    public class MainContext:DbContext
    {
        public DbSet<User> Users { get; set; } 
    }
}