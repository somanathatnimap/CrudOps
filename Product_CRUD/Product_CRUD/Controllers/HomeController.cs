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
                    TempData["Insert"]  = "<script>alert('Data Inserted Succesfully...!')</script>";
                }
                
            }
            else
            {
                TempData["Insert"] = "Please Insert Valid Data";
                return View();
            }

            return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
            else
            {
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
                return RedirectToAction("Index");
            }
            return View();
          
        }
        public ActionResult product_index(int id)
        {
            var p_data = db.products.Where(Model=>Model.categories_id==id).ToList();
            TempData["categories_id"] = id;
            string categories_name = db.categories.Where(Model => Model.id==id ).Select(Model => Model.category_name).FirstOrDefault();
            TempData["categories_name"] = categories_name;
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
            products.categories_id = (int)TempData["categories_id"];
            db.products.Add(products);
            int count=db.SaveChanges();
                if (count > 0)
                {
                    TempData["create"] = "<script>alert('Product Inserted Succesfully...!')</script>";
                     return RedirectToAction("product_index", "Home", new { id = products.categories_id });
                }
            }
            else{
                TempData["create"] = "<script>alert('Product Inserted Succesfully...!')</script>";
                return View();
            }
            return View();
        }
        public ActionResult product_update(int id)
        {
            var p_data = db.products.Where(Model => Model.id == id).FirstOrDefault();
            return View(p_data);
        }
        [HttpPost]
        public ActionResult product_update(Products products)
        {
            products.categories_id = (int)TempData["categories_id"];
            db.Entry(products).State = EntityState.Modified;
            var count=db.SaveChanges();
            if (count > 0)
            {
                    TempData["update"]  = "<script>alert('Data Updated Succesfully...!')</script>";
                return RedirectToAction("product_index", "Home", new { id = products.categories_id });

            }
            else
            {
                    TempData["update"]  = "<script>alert('Data Updated Succesfully...!')</script>";
                return View();
            }
        }
        public ActionResult product_delete(int id)
        {
            var p_data=db.products.Where(Model=>Model.id==id).FirstOrDefault();
            return View(p_data);
        }
        [HttpPost]
        public ActionResult product_delete(Products products)
        {
            db.Entry(products).State = EntityState.Deleted;
            int count=db.SaveChanges();
            if(count > 0)
            {
               TempData["delete"]  = "<script>alert('Data Deleted Succesfully...!')</script>";

                return RedirectToAction("categories", "Home");
              
            }
            return View();   
        }
    }
}