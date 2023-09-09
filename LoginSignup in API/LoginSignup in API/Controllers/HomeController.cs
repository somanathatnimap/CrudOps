using LoginSignup_in_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginSignup_in_API.Controllers
{
    public class HomeController : Controller
    {
        MainContext db = new MainContext();

        [HttpPost]
        public ActionResult Index(user u)
        {
            var data=db.users.Add(u);
            return View();
        }
    }
}
