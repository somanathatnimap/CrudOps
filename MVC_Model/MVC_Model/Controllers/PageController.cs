using MVC_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Model.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            var data = employee();
            ViewBag.myprop = "somanath";
            ViewData["mydata"] = "Barge";
            ViewBag.mylist = new List<string> { "soma", "omkar" };
            ViewData["view"] = new List<string> { "ram", "sham", "om" };

            return View(data);
        }
        private Employee employee()
        {
            return new Employee ()
            {
                id = 1,name="soma",address="pune"
            };
        }
    }
}