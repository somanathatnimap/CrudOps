using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApproch.Models
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> students { get; set; }
    }
}