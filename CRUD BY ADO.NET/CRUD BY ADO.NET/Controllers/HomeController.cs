using CRUD_BY_ADO.NET.Models;
using CRUD_BY_ADO.NET.Service;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CRUD_BY_ADO.NET.Controllers
{
    public class HomeController : Controller
    {
            StudentDAL studentDAL = new StudentDAL();
        public ActionResult Index()
        {
            var data = studentDAL.GetUser();
            return View(data);
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Student student)
        {
            if (studentDAL.InsertUser(student))
            {
                TempData["InsertMsg"] = "Data Inserted Successfully (:...!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Data Not Inserted ):...!";

            }
            return View();
        }
        public ActionResult Edit(int Id)
        {
            var data = studentDAL.GetUser().Find(x=>x.Id == Id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (studentDAL.EditUser(student))
            {
                TempData["InsertMsg"] = "Data Updated Successfully :)...!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Data Not Updated ):...!";

            }
            return View();
        }
        public ActionResult Delete(int Id)
        {
            var data =studentDAL.GetUser().Find(x=>x.Id==Id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            int r = studentDAL.DeleteUser(student);
            if (r>0)
            {
                TempData["InsertMsg"] = "Data Deleted Successfully :)...!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["InsertErrorMsg"] = "Data Not Deleted ):...!";

            }
            return View();

        }

    }
}