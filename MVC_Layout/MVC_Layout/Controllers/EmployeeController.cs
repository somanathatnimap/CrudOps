using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Layout.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Route("form")]
        public ActionResult GetData()
        {
            return View();
        }
        [Route("result")]
        public ActionResult ShowData()
        {
            return View();
        }
    }
}