using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Model.Controllers
{
    public class TempController : Controller
    {
        // GET: Temp
        
        public ActionResult Index1()
        {
            //Session.Abandon();
            TempData["mydata"] = "tempdata from index 1";
            return View();
        }
        public ActionResult Index2()
        {
            ViewBag.mydat = TempData["data"];
            return View();
        }
        public ActionResult Index3()
        {
           // ViewBag.mydat = TempData["mydata"];
            ViewBag.mydata = TempData["data"];
            return View();
        }
    }
}