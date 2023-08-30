using Repo_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repo_Pattern.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MainContext db=new MainContext();
        public ActionResult Index()
        {
            var data=db.Student.Where(model=>model.Id!=0).ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            db.Student.Add(student);
            db.SaveChanges();
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data=db.Student.Where(x=>x.Id==id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {   if(ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        return View();
            
        }
        public ActionResult Delete(int id)
        {
            var data = db.Student.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            db.Entry(student).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}