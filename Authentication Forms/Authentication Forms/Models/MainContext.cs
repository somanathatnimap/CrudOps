using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Authentication_Forms.Models
{
    public class MainContext:DbContext
    {
        public DbSet<Signup> Signup { get; set; }
    }
}