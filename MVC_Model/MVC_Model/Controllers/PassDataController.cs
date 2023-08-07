using Microsoft.Ajax.Utilities;
using MVC_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
        public string postByBinding(PassData pd)
        {
            string fname = pd.firstname;
            string lname = pd.lastname;
            string mail = pd.email;
            int uage = pd.age;
            return $"{fname}+{lname}+{mail}+{uage}";
        }

        [Route("validation")]
        
        public ActionResult Validation(PassData pd)
        
        
        {
            if(ModelState.IsValid)
            {
                return View("Index");
            }
            return View("Validation");
        }

    }
}