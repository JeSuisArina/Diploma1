using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternalAuditSystem.Models.EntityModels;

namespace InternalAuditSystem.Controllers
{
    public class ApplicationsController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Applications
        public ActionResult Index()
        {
            return View(db.ApplicationsView.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationsView applicationsView = db.ApplicationsView.Find(id);
            if (applicationsView == null)
            {
                return HttpNotFound();
            }
            return View(applicationsView);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandartId,ApplicationDateTime,ApplicationFile,ApplicationId,UserId,ApplicationContent")] Applications applications, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                byte[] fileData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(uploadFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(uploadFile.ContentLength);
                }
                // установка массива байтов
                applications.ApplicationFile = fileData;
                applications.ApplicationDateTime = DateTime.Now;
                applications.UserId = 1;
                db.Applications.Add(applications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applications);
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationsView applicationsView = db.ApplicationsView.Find(id);
            if (applicationsView == null)
            {
                return HttpNotFound();
            }
            return View(applicationsView);
        }

        // POST: Applications/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserLastName,UserName,StandartName,ApplicationDateTime,ApplicationFile,ApplicationId,UserMiddleName,ApplicationContent")] ApplicationsView applicationsView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationsView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationsView);
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationsView applicationsView = db.ApplicationsView.Find(id);
            if (applicationsView == null)
            {
                return HttpNotFound();
            }
            return View(applicationsView);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationsView applicationsView = db.ApplicationsView.Find(id);
            db.ApplicationsView.Remove(applicationsView);
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
