using Authorizationfilters.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Authorizationfilters.cs.Controllers
{
    
    public class LoginController : Controller
    {
        MainContext db=new MainContext();
        // GET: Login
        public ActionResult Login()
        {
           // var data = db.Users.ToList();
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (IsValid(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, true);
                var usercookies = new HttpCookie("Username", email);
                Response.Cookies.Add(usercookies);

                Session["Username"] = email.ToString();
                return RedirectToAction("index", "home");
            }
            else
            {
                ViewBag.error = "invalid user";
                return View("login");
            }
        }

        private bool IsValid(string email, string password)
        {
            var status = db.Users.Where(model => model.email == email && model.password == password).FirstOrDefault();
            if (status != null)
            {
                TempData["user"] = email;
                return true;
            }
            else
            {
                return false;
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}