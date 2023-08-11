using Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                int a=db.SaveChanges();
                if(a>0)
                {
                    TempData["InsertMessage"] = "Category Added Succesfully...!";
                    return RedirectToAction("Index");
                }
            }
            else 
            {
                TempData["InsertFailMessage"] = "Category Not Added...!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult update_categories(int id)
        {
            var row=db.categories.Where(Model=>Model.id==id).ToList().FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult update_categories(categories category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                TempData["UpdateMessage"] = "Category Updated Succesfully...!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateFailedMessage"] = "Category Not Updated...!";
                return RedirectToAction("Index");
            }
        }
        public ActionResult delete_categories(int id)
        {
            var row = db.categories.Where(Model => Model.id == id).ToList().FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult delete_categories(categories category)
        {
                db.Entry(category).State = EntityState.Deleted;
                int a=db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "Category Deleted Succesfully...!";
                return RedirectToAction("Index");
            }
            return View();
          
        }
        public ActionResult product_index(int id)
        {
            var p_data = db.products.Where(Model=>Model.categories_id==id).ToList();
            TempData["categories_id"] = id;
            return View(p_data);
        }
        public ActionResult products()
        {
            return View();
        }
        [HttpPost]
        public ActionResult products(Products products)
        {
            if(ModelState.IsValid)
            {
            db.products.Add(products);
            db.SaveChanges();
            return RedirectToAction("product_index");
            }
            return View();
        }

    }
}