using Authorizationfilters.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authorizationfilters.cs.Controllers
{
    public class HomeController : Controller
    {
        MainContext db=new MainContext();
        public ActionResult Index()
        {
           // TempData["user1"]= TempData["user"];
           var name =Request.Cookies["Username"].Value;
            string session = Session["Username"] as string;



            ViewBag.Name = name;
            ViewBag.Session = session;
            return View(); 
        }
        public ActionResult About()
        {
            ViewBag.Time=DateTime.Now.ToLongTimeString();
            ViewBag.Date=DateTime.Now.ToLongDateString();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}