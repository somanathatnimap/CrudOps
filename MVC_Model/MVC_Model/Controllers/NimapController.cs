using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Model.Models;

namespace MVC_Model.Controllers
{
    public class NimapController : Controller
    {
        // GET: Nimap
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("soma")]
        public ActionResult Index(Nimap np)
        {
            if(ModelState.IsValid)
            {
                ModelState.Clear();
                return View("Index");
            }
            return View();
        }
    }
}