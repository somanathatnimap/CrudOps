using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Product_CRUD.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string Product_name { get; set; }
        [Required(ErrorMessage = "Please Enter Product price")]
        public int Product_price { get; set;}
        [Required(ErrorMessage = "Please Enter Product Description")]
        public string Product_description { get; set;}
        public int categories_id { get; set; }
        [ForeignKey("categories_id")]
        public categories categories { get; set;}
    }
}

