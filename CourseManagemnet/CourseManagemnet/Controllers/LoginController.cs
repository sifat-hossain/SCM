using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManagemnet.Models;

namespace CourseManagemnet.Controllers
{
    public class LoginController : Controller
    {
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
           
           

            
            if (login.Name == null ||login.Password==null)
            {
                ViewBag.Message = "username required";
                return View();
            }
            if(login.Name.Equals("Admin") && login.Password.Equals("12345"))
            {

                Session["Name"] = login.Name;

                return RedirectToAction("../AdminUpdate/Index");
            }
            if (login.Name.Equals("Executive") && login.Password.Equals("12345"))
            {
                Session["Name"] = login.Name;
                return RedirectToAction("../StudentRegistration/registration");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["Name"] = null;
            return View();
        }

        [HttpPost]
        [ActionName("Logout")]
        public ActionResult Logout_post()
        {
          
            Session.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}