using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Model.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult StudentIndex(int id)
        {
            return View();
        }
    }
}