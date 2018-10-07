using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManagemnet.Models;
using Rotativa;

namespace CourseManagemnet.Controllers
{
    public class AdminUpdateController : Controller
    {
        private SCMEntities db = new SCMEntities();

        // GET: AdminUpdate
        public ActionResult Index()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            var tblStudent_info = db.tblStudent_info.Include(t => t.tblBatch).Include(t => t.tblCourse);
            return View(tblStudent_info.ToList());
        }

        // GET: AdminUpdate/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent_info tblStudent_info = db.tblStudent_info.Find(id);
            if (tblStudent_info == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent_info);
        }

        // GET: AdminUpdate/Create
        public ActionResult Create()
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            ViewBag.Batch_id = new SelectList(db.tblBatches, "ID", "Name");
            ViewBag.Course_id = new SelectList(db.tblCourses, "ID", "Name");
            return View();
        }

        // POST: AdminUpdate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Cell,Email,Father_name,Mother_name,Adress,Course_id,Batch_id,Result")] tblStudent_info tblStudent_info)
        {
            if (ModelState.IsValid)
            {
                db.tblStudent_info.Add(tblStudent_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_id = new SelectList(db.tblBatches, "ID", "Name", tblStudent_info.Batch_id);
            ViewBag.Course_id = new SelectList(db.tblCourses, "ID", "Name", tblStudent_info.Course_id);
            return View(tblStudent_info);
        }

        // GET: AdminUpdate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent_info tblStudent_info = db.tblStudent_info.Find(id);
            if (tblStudent_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_id = new SelectList(db.tblBatches, "ID", "Name", tblStudent_info.Batch_id);
            ViewBag.Course_id = new SelectList(db.tblCourses, "ID", "Name", tblStudent_info.Course_id);
            return View(tblStudent_info);
        }

        // POST: AdminUpdate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Cell,Email,Father_name,Mother_name,Adress,Course_id,Batch_id,Result")] tblStudent_info tblStudent_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_id = new SelectList(db.tblBatches, "ID", "Name", tblStudent_info.Batch_id);
            ViewBag.Course_id = new SelectList(db.tblCourses, "ID", "Name", tblStudent_info.Course_id);
            return View(tblStudent_info);
        }

        //GET: AdminUpdate/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblStudent_info tblStudent_info = db.tblStudent_info.Find(id);
        //    if (tblStudent_info == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblStudent_info);
        //}

        //POST: AdminUpdate/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tblStudent_info tblStudent_info = db.tblStudent_info.Find(id);
        //    db.tblStudent_info.Remove(tblStudent_info);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        [ActionName("Print")]
        public ActionResult IndexById(int id)
        {
            if (Session["Name"] == null)
            {
                return RedirectToAction("../Login/Index");
            }
            if (Session["Name"].Equals("Executive"))
            {
                return RedirectToAction("../StudentRegistration/Registration");
            }
            var emp = db.tblStudent_info.Where(e => e.ID == id).First();
            return View(emp);
        }

        [HttpPost]
        [ActionName("Print")]
        public ActionResult PrintDetails(int id)
        {
            var report = new ViewAsPdf("IndexById", new { id = id });
            return report;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
