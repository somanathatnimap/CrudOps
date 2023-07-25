using CodeFirstApproch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproch.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db=new StudentContext();
        
        // GET: Home
        public ActionResult Index()
        {
            var data=db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid==true)
            {
                db.students.Add(s);
            int a=db.SaveChanges();
            if (a > 0)
            {
                    // ViewBag.InsertMessage = "<script>alert('Data Inserted')</script>";
                    // ModelState.Clear();
                    TempData["InsertMessage"] = "Data Inserted Successfully...!";
                    return RedirectToAction("Index");
            }
            else
            {
                ViewBag.InsertMessage = "<script>alert('Data Not Inserted')</script>";
            }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row=db.students.Where(Model=>Model.id==id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;

                int b = db.SaveChanges();
                if (b > 0)
                {
                    TempData["InsertMessage"] = "Data Updated Successfully...!";
                    return RedirectToAction("Index");
                }
            }
          return View();
            
        }
        public ActionResult Delete(int id)
        {
            var studentIdRaw=db.students.Where(Model=>Model.id == id).FirstOrDefault();
            return View(studentIdRaw);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State= EntityState.Deleted;
            int a=db.SaveChanges();
            if(a > 0)
            { 
                TempData["InsertMessage"] = "Data Deleted Successfully...!";
                return RedirectToAction("Index");
            }
            return View();
            
        }
        
        public ActionResult Details(int id)
        {
            var StudentIdDetails = db.students.Where(Model => Model.id == id).FirstOrDefault();
            return View(StudentIdDetails);
            
        }
    }
}