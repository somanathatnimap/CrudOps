using Product_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Product_CRUD.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        MainContext db = new MainContext();
        // GET: Home
        public ActionResult Dashboard()
        {
            return View();
        }
        /* public async Task<ActionResult> Index()
         {
              var c_data = await db.categories.ToListAsync();
              return View(c_data);

         } */

        public async Task<ActionResult> Index(int page = 1, int pageSize = 5)
        { var userRole=GetUserRole();
            if(userRole == "admin")
            {
                TempData["userRole"] = "Admin";
            }
            else
            {
                TempData["userRole"] = "User";
            }
            var username = Request.Cookies["username"].Value;
            var c_data = await db.categories.OrderBy(c => c.id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            int totalItems = await db.categories.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            ViewBag.username = username;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = page;
            return View(c_data);
        }
        public ActionResult categories()
        {
            var userRole=GetUserRole();
            if(userRole=="admin")
            {

            return View();
            }
            else
            {
                TempData["Insert"] = "Only Admin have permission to perform this action.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> categories(categories cat)
        {
            if (ModelState.IsValid)
            {
                db.categories.Add(cat);
                int a = await db.SaveChangesAsync();
                if (a > 0)
                {
                    TempData["Insert"] = "<script>alert('Data Inserted Successfully...!')</script>";
                }
            }
            else
            {
                TempData["Insert"] = "Please Insert Valid Data";
                return View();
            }
            return RedirectToAction("Index");
        }
        //method form user authorization
        private string GetUserRole()
        {
            var username = Request.Cookies["username"].Value;
            var user = db.Users.SingleOrDefault(u => u.Email == username);
            if (user != null)
            {
                if (user.Role == true)
                {
                    return "admin";
                }
                else
                {
                    return "user";
                }
            }
            return "user";
        }
        public async Task<ActionResult> update_categories(int id)
        {
            var userRole=GetUserRole();
            if (userRole == "admin")
            {
                var row = await Task.Run(() =>
                {
                    return db.categories.Where(Model => Model.id == id).ToList().FirstOrDefault();
                });
                return View(row);
            }
            else
            {
                TempData["Insert"] = "You do not have permission to perform this action.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> update_categories(categories category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<ActionResult> delete_categories(int id)
        {
            var userRole=GetUserRole();
            if(userRole == "admin")
            {
            var row = db.categories.Where(Model => Model.id == id).ToList().FirstOrDefault();
            return View(row);
            }
            else
            {
                TempData["Insert"] = "You do not have permission to perform this action.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> delete_categories(categories category)
        {
                db.Entry(category).State = EntityState.Deleted;
                int a=await db.SaveChangesAsync();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
          
        }
        public async Task<ActionResult> product_index(int id)
        {
            var p_data = await db.products.Where(Model=>Model.categories_id==id).ToListAsync();
            TempData["categories_id"] = id;
            string categories_name =await db.categories.Where(Model => Model.id==id ).Select(Model => Model.category_name).FirstOrDefaultAsync();
            TempData["categories_name"] = categories_name;
            return View(p_data);
        }
        public async Task<ActionResult> products()
        {
            var userRole = GetUserRole();
            if(userRole=="admin")
            {
            return View();
            }
            else
            {
                TempData["Insert"] = "You do not have permission to perform this action.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> products(Products products)
        {
            if(ModelState.IsValid)
            {
            products.categories_id = (int)TempData["categories_id"];
            db.products.Add(products);
            int count=await db.SaveChangesAsync();
                if (count > 0)
                {
                    TempData["create"] = "<script>alert('Product Inserted Succesfully...!')</script>";
                     return RedirectToAction("product_index", "Home", new { id = products.categories_id });
                }
            }
            else{
                TempData["create"] = "<script>alert('Product Not Inserted Succesfully...!')</script>";
                return View();
            }
            return View();
        }
        public async Task<ActionResult> product_update(int id)
        {
            var userRole = GetUserRole();
            if (userRole == "admin")
            {
            var p_data = await db.products.Where(Model => Model.id == id).FirstOrDefaultAsync();
            return View(p_data);
            }
            else
            {
                TempData["Insert"] = "You do not have permission to perform this action.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> product_update(Products products)
        {
            products.categories_id = (int)TempData["categories_id"];
            db.Entry(products).State = EntityState.Modified;
            var count=await db.SaveChangesAsync();
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
        public async Task<ActionResult> product_delete(int id)
        {
            var userRole = GetUserRole();
            if(userRole== "admin")
            {
            var p_data=await db.products.Where(Model=>Model.id==id).FirstOrDefaultAsync();
            return View(p_data);
            }
            else
            {
                TempData["Insert"] = "You do not have permission to perform this action.";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<ActionResult> product_delete(Products products)
        {
            db.Entry(products).State = EntityState.Deleted;
            int count=await db.SaveChangesAsync();
            if(count > 0)
            {
               TempData["delete"]  = "<script>alert('Data Deleted Succesfully...!')</script>";

                return RedirectToAction("Index", "Home");
              
            }
            return View();   
        }
        public async Task<ActionResult> Catergory_Status(int id)
        {
            var catergory = await db.categories.FindAsync(id);
            catergory.catergory_status = !catergory.catergory_status;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       


    }
}