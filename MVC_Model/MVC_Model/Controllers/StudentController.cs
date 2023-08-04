using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Model.Models;

namespace MVC_Model.Controllers
{
    [RoutePrefix("home")]
    public class StudentController : Controller
    {
        // GET: Student

        public ActionResult StudentIndex()
        {
            return View();
        }
        [Route("student")]
        public ActionResult GetAllStudents()
        {
            var students = GetStudents();
            return View(students);
        }
        [Route("thatstudent/{id:int}")]
        public ActionResult GetStudent(int id)
        {
            var student = GetStudents().FirstOrDefault(x => x.id == id);
            return View(student);
        }
        public ActionResult GetStudentAddress(int id)
        {
            var studentaddress = GetStudents().Where(x => x.id == id).Select(x => x.Address).FirstOrDefault();
            return View(studentaddress);
        }
        private List<Student> GetStudents()
        {
            return new List<Student>()
            {
            new Student()
            {
                id = 1,
                name = "soma",
                age = 22,
                Address = new StudentAddress()
                {
                    HomeNo = 21,
                    Address = "Pune",
                    City = "Pune"
                }
            }

            };

        }
        [Route("{id}")]
        public string Mystring(string id)
        {
            return id;
        }
    }
}
        