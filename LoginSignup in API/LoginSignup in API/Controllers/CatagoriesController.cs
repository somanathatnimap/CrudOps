using LoginSignup_in_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace LoginSignup_in_API.Controllers
{
    public class CatagoriesController : ApiController
    {
        MainContext db = new MainContext();
        public IHttpActionResult GetCatagories()
        {
            var data=db.catagories;
            return Ok(data);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult AddCatagories(Catagories catagories)
        {
            var data=db.catagories.Add(catagories);
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult EditCatagories(int id)
        {
            var data=db.catagories.Where(x=>x.id==id).ToList();
            return Ok(data);
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditCatagories(Catagories catagories)
        {
            db.Entry(catagories).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCatagories(Catagories catagories)
        {
            db.Entry(catagories).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
