using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace First_Crud_using_API.Controllers
{
    public class HomeController : ApiController
    {
        public string[] myStudents = {"Soma","Nikhil","Ram" };
        [HttpGet]
        public string[] GetStudent()
        {
            return myStudents;
        }
        [HttpGet]
        public string GetStudentIndex(int id) 
        {
            return myStudents[id];
        }
    }
}
