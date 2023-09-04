using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Crud_using_Api_and_stored_procedure.Models
{
    public class MainContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}