using Crud_using_Api_and_stored_procedure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Crud_using_Api_and_stored_procedure.Controllers
{
    public class ValuesController : ApiController
    {
        MainContext db=new MainContext();
        public IEnumerable<Student> Get()
        {
            return db.Students.ToList();
        }

        // GET api/values/5
        public Student Get(int id)
        {
            return db.Students.Find(id);
        }
       
        [HttpPost]
        public Student Post([FromBody] Student student)
        {
            var data =db.Students.Add(student);
            db.SaveChanges();
            return data;
        }
        [HttpPut]
        public void Put(int id, [FromBody] Student student)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete([FromBody] Student student)
        {
           db.Entry(student).State= EntityState.Deleted;
           db.SaveChanges();
        }
    }
}
