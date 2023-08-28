using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Result_Filter.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration =10)]
        public ActionResult Index()
        {
            ViewBag.Date = DateTime.Now.ToLongDateString();
            ViewBag.Time = DateTime.Now.ToLongTimeString();
            return View();
        }
          
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}