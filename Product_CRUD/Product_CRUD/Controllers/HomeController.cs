using Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace Product_CRUD.Controllers
{
    public class HomeController : Controller
    {
        MainContext db=new MainContext();
        // GET: Home
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Index()
        {
             var c_data = db.categories.ToList();
             return View(c_data);
        }
        public ActionResult categories()
        {
            return View();
        }
        [HttpPost]
        public ActionResult categories(categories cat)
        {
            if (ModelState.IsValid)
            {
                db.categories.Add(cat);
                db.SaveChanges();
            }
           
            return RedirectToAction("Index");
        }
    }
}