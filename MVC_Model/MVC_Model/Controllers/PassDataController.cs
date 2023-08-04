using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Model.Controllers
{
    public class PassDataController : Controller
    {
        // GET: PassData
        [HttpGet]
        [Route("form")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string postByParameters(string firstname)
        {
            return firstname;
        }
        public string postByRequest()
        {
            var fname = Request["firstname"];
            return fname;
        }
        public string postByFormcollection(FormCollection form)
            {
            string fname = form["firstname"];
            return fname;
        }
    }
}