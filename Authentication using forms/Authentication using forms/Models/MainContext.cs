using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authentication_using_forms.Models
{
    public class MainContext: DbContext
    {
        public DbSet<Credintials> credintials { get; set; }
}
}