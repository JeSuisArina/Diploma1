using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using InternalAuditSystem.Models.EntityModels;
using Microsoft.AspNet.Identity;

namespace InternalAuditSystem.Controllers
{
    public class ApplicationsController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Applications
        public ActionResult Index()
        {
            string userEmail = User.Identity.GetUserName();
            //Users user = db.Users.Where(u => u.UserEmail == userEmail).FirstOrDefault();            
            //Applications applications = db.Applications.Where(u => u.UserId == user.UserId).FirstOrDefault();
            //var applicationsView = db.ApplicationsView.Where(a => a.ApplicationId == applications.ApplicationId).FirstOrDefault();
            //ViewBag.Application = applicationsView;
            return View(db.ApplicationsView.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            string userEmail = User.Identity.GetUserName();
            Users user = db.Users.Where(u => u.UserEmail == userEmail).FirstOrDefault();
            ViewBag.UserLastName = user.UserLastName;
            ViewBag.UserName = user.UserName;
            ViewBag.UserMiddleName = user.UserMiddleName;
            ViewBag.UserEmail = user.UserEmail;
            ViewBag.UserPhone = user.UserPhone;
            var userSubdivision = db.Subdivisions.Where(s => s.SubdivisionId == user.SubdivisionId).FirstOrDefault();
            ViewBag.UserSubdivision = userSubdivision.SubdivisionName;

            ViewBag.StandartsList = new SelectList(db.Standarts, "StandartId", "StandartName");
            return View();
        }

        // POST: Applications/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandartId,ApplicationDateTime,ApplicationId,UserId,ApplicationContent")] Applications applications)
        {
            if (ModelState.IsValid)
            {
                string userEmail = User.Identity.GetUserName();
                Users user = db.Users.Where(u => u.UserEmail == userEmail).FirstOrDefault();
                applications.UserId = user.UserId;
                applications.ApplicationDateTime = DateTime.Now;
                db.Applications.Add(applications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applications);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.StatusList = new SelectList(db.ApplicationStatuses, "ApplicationStatusId", "ApplicationStatus");
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // POST: Applications/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Applications applications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applications);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applications applications = db.Applications.Find(id);
            if (applications == null)
            {
                return HttpNotFound();
            }
            return View(applications);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Applications applications = db.Applications.Find(id);
            db.Applications.Remove(applications);
            db.SaveChanges();
            return RedirectToAction("Index");
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
