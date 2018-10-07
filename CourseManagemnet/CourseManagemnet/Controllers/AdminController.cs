using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManagemnet.Models;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace CourseManagemnet.Controllers
{
    public class AdminController : Controller
    {
        SCMEntities sCMEntities = new SCMEntities();
        Base b = new Base();

        [HttpGet]
        [ActionName("Add_course")]
        public ActionResult Get_course()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            return View();
        }
        [HttpPost]
        [ActionName("Add_course")]
        public ActionResult Post_course(Course course)
        {
            if(ModelState.IsValid)
            {
               
                b.AddCourse(course);
               
                return RedirectToAction("Add_course");
            }
            return View();
        }

        [HttpGet]
        [ActionName("Add_Batch")]
        public ActionResult Get_Batch()
        {
            List<tblCourse> CourseList = sCMEntities.tblCourses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "ID", "Name");

            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            return View();
        }

        [HttpPost]
        [ActionName("Add_Batch")]
        public ActionResult Post_Batch(Batch batch)
        {
            if(ModelState.IsValid)
            {
                b.AddBatch(batch);
                return RedirectToAction("Add_Batch");
            }
            return View();
        }

     
    }
}