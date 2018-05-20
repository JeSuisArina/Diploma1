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
            var sertificates = db.Sertificates.Include(s => s.Standarts).Include(s => s.Subdivisions);
            return View(sertificates.ToList());
        }
        public ActionResult Reports()
        {
            var sertificates = db.Sertificates.Include(s => s.Standarts).Include(s => s.Subdivisions);
            return View(sertificates.ToList());
        }

        // GET: Sertificates/Details/5
        public ActionResult Details(int? id)
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

        // GET: Sertificates/Create
        public ActionResult Create()
        {
            ViewBag.StandartId = new SelectList(db.Standarts, "StandartId", "StandartName");
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName");
            return View();
        }

        // POST: Sertificates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SertificateId,SubdivisionId,StandartId,SertificateDate,SertificateShelfLife")] Sertificates sertificates)
        {
            if (ModelState.IsValid)
            {
                db.Sertificates.Add(sertificates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StandartId = new SelectList(db.Standarts, "StandartId", "StandartName", sertificates.StandartId);
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", sertificates.SubdivisionId);
            return View(sertificates);
        }

        // GET: Sertificates/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.StandartId = new SelectList(db.Standarts, "StandartId", "StandartName", sertificates.StandartId);
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", sertificates.SubdivisionId);
            return View(sertificates);
        }

        // POST: Sertificates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SertificateId,SubdivisionId,StandartId,SertificateDate,SertificateShelfLife")] Sertificates sertificates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sertificates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandartId = new SelectList(db.Standarts, "StandartId", "StandartName", sertificates.StandartId);
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", sertificates.SubdivisionId);
            return View(sertificates);
        }

        // GET: Sertificates/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            Sertificates sertificates = db.Sertificates.Find(id);
            db.Sertificates.Remove(sertificates);
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
