﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Product_CRUD.Models
{
    public class MainContext:DbContext
    {
       public DbSet<categories> categories { get; set; }
       public DbSet<Products> products { get; set; }
    }
}