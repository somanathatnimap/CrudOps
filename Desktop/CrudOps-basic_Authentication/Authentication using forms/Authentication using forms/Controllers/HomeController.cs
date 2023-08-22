using Authentication_using_forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Authentication_using_forms.Controllers
{
    public class HomeController : Controller
    {
        MainContext db=new MainContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Credintials credintials)
        {
            db.credintials.Add(credintials);
            db.SaveChanges();
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            var status=db.credintials.Where(x=>x.email==email && x.password==password).FirstOrDefault();
            if (status != null)
            {
                var token = JwtAuthentication.CreateJWTToken(email);
                ViewBag.Token = token;

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

    }
}