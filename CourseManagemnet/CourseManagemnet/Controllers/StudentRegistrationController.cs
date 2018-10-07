using CourseManagemnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;


namespace CourseManagemnet.Controllers
{
    public class StudentRegistrationController : Controller
    {
        SCMEntities sCMEntities = new SCMEntities();

        [HttpGet]
        [ActionName("Registration")]
        public ActionResult Registration_get()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Admin"))
            {
                return RedirectToAction("../AdminUpdate/Index");
            }

            List<tblCourse> CourseList = sCMEntities.tblCourses.ToList();
            ViewBag.CourseList = new SelectList(CourseList, "ID", "Name");

            List<tblBatch> BatcheList = sCMEntities.tblBatches.ToList();
            ViewBag.BatchList = new SelectList(BatcheList, "ID", "Name");

            return View();
        }
        public JsonResult GetBatchById(int id)
        {
            //sCMEntities.Configuration.ProxyCreationEnabled = false;
           // List<tblBatch> BatcheList = sCMEntities.tblBatches.ToList();
            

            return Json(new SelectList(sCMEntities.tblBatches.Where(cs => cs.CourseId == id), "ID", "Name"), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Registration")]
        public ActionResult Registration_post(StudentRegistration studentRegistration)
        {
           
            if(ModelState.IsValid)
            {
                Base b = new Base();
                b.AddStudent(studentRegistration);

                return RedirectToAction("Registration");
            }
            return View();
        }
    }
}