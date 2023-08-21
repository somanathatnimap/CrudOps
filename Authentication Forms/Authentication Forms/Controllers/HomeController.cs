using Authentication_Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Authentication_Forms.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MainContext db=new MainContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Signup signup)
        {
            db.Signup.Add(signup);
            db.SaveChanges();
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {
            var status=db.Signup.Where(x=>x.email == Email && x.password == Password).FirstOrDefault();
            if (status != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["usernotfound"] = "<script>alert('Incorrect user id or password...!')</script>";
                return RedirectToAction("Login");
            }
        }
    }
}