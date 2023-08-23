using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Filters.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }
    }
}














/*
 try
            {
                int a = 10;
                int b = 0;
                int c = a / b;
                ViewData["c"] = $"division is {c}";
            }
            catch (Exception ex)
            {
                ViewData["c"] = $"exception thrown";

            }

 try
            {
                throw new Exception(){ };
            }
            catch 
            {
                RedirectToAction("ErrorPage", "Home");
            }
            return View();
        }
        public ActionResult ErrorPage()
        {
            return View();
        }
 */