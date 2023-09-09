using LoginSignup_in_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginSignup_in_API.Controllers
{
    public class UserController : ApiController
    {
        MainContext db=new MainContext();

        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(user u)
        {
                var data=db.users.FirstOrDefault(x=>x.Email == u.Email && x.Password==u.Password);
                if (data != null)
                {
                    return Ok("Login Success");
                }
                else
                {
                    return Ok("Login Unsuccesfull");
                }
        }
    }
}
