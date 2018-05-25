using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InternalAuditSystem.Models.EntityModels;

namespace InternalAuditSystem.Controllers
{
    public class SertificatesController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Sertificates
        public ActionResult Index()
        {
            return View(db.SertificatesView.ToList());
        }

        public ActionResult Reports()
        {
            return View(db.SertificatesView.ToList());
        }

        // GET: Sertificates/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SertificatesView sertificatesView = db.SertificatesView.Find(id);
            if (sertificatesView == null)
            {
                return HttpNotFound();
            }
            return View(sertificatesView);
        }

        // GET: Sertificates/Create
        public ActionResult Create()
        {
            ViewBag.SubdivisionList = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName");
            ViewBag.UsersList = new SelectList(db.Users, "UserId", "UserLastName");
            return View();
        }

        // POST: Sertificates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sertificates sertificates)
        {
            if (ModelState.IsValid)
            {
                sertificates.Discrepancy = false;
                db.Sertificates.Add(sertificates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sertificates);
        }

        // GET: Sertificates/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sertificates sertificates = db.Sertificates.Find(id);
            if (sertificates == null)
            {
                return HttpNotFound();
            }
            return View(sertificates);
        }

        // POST: Sertificates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sertificates sertificates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sertificates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sertificates);
        }

        // GET: Sertificates/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sertificates sertificates = db.Sertificates.Find(id);
            if (sertificates == null)
            {
                return HttpNotFound();
            }
            return View(sertificates);
        }

        // POST: Sertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SertificatesView sertificatesView = db.SertificatesView.Find(id);
            db.SertificatesView.Remove(sertificatesView);
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
