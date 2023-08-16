using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Product_CRUD.Models
{
    public class categories
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Please Enter category Name")]
        public string category_name { get; set; }

        [Required(ErrorMessage = "Please Enter category Description")]
        public string category_description { get; set; }

        public bool catergory_status { get; set; }

    }
}