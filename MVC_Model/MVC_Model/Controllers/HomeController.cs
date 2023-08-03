using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Model.Models;

namespace MVC_Model.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var data = GetEmployee();
            return View(data);
        }
       
        private Employee GetEmployee()
        {
            return new Employee()
            {
                id = 1,
                name = "Test",
                address = "satara"
            };
        }

    }
}