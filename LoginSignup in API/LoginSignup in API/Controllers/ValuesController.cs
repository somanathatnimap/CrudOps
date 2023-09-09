using LoginSignup_in_API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginSignup_in_API.Controllers
{
    public class ValuesController : ApiController
    {
        MainContext db=new MainContext();
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] user user)
        {
            var data = db.users.Add(user);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
