using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session_Example.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewData["var1"] = "This is view data";
            TempData["var2"] = "This is temp data";
            ViewBag.var3 = "This is View Bag";
            Session["var4"] = "this is session";

            string[] names = { "soma", "gaurav", "viraj", "omkar" };
            Session["var5"]= names;
            return View();
        }
       public ActionResult About()
        {

            return View();
        }
    }
}