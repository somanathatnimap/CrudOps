using Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Product_CRUD.Controllers
{
    public class UserController : Controller
    {
        MainContext db = new MainContext();
        // GET: User
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Users users)
        {
            db.Users.Add(users);
            db.SaveChanges();
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string  Email, String Password)
        {
            if (IsValid(Email, Password))
            {
                FormsAuthentication.SetAuthCookie(Email, true);
                var usercookies = new HttpCookie("username",Email);
                Response.Cookies.Add(usercookies);
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return RedirectToAction("Login", "User");
            }
        }
        public bool IsValid(string Email, string Password)
        {
            var user=db.Users.Where(model=> model.Email == Email && model.Password==Password).FirstOrDefault();
            if (user != null)
            {
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
            return RedirectToAction("Login", "User");
        }
    }
}