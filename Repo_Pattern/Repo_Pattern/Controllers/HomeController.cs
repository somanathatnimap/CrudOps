using Repo_Pattern.Models;
using Repo_Pattern.Repository;
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
        private readonly IStudent _studentRepository;
        public HomeController()
        {
            _studentRepository = new StudentRepository();
        }
        MainContext db =new MainContext();
        public ActionResult Index()
        {
            var data = _studentRepository.GetAllStudent();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentRepository.AddStudent(student);
            return View();
        }

        public ActionResult Edit(int id)
        {
            var data=_studentRepository.getStudentById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {   if(ModelState.IsValid)
            {
                _studentRepository.UpdateStudent(student);
                return RedirectToAction("Index");
            }
        return View();
            
        }
        public ActionResult Delete(int id)
        {
            var data = _studentRepository.getStudentById(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            db.Entry(student).State = EntityState.Deleted;
            return RedirectToAction("Index");
        }
    }

}