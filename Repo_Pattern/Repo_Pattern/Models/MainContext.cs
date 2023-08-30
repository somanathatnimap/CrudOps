using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repo_Pattern.Models
{
    public class MainContext:DbContext 
    {
        public DbSet<Student> Student{ get; set; }
    }
}