using Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product_CRUD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Users users)
        {
            return View();
        }
    }
}