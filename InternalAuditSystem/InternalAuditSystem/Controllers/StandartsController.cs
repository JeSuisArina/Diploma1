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
    public class StandartsController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Standarts
        public ActionResult Index()
        {
            return View(db.Standarts.ToList());
        }

        // GET: Standarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standarts standarts = db.Standarts.Find(id);
            if (standarts == null)
            {
                return HttpNotFound();
            }
            return View(standarts);
        }

        // GET: Standarts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Standarts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandartId,StandartName,StandartDescription,StandartFile")] Standarts standarts, HttpPostedFileBase uploadFile)
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
                standarts.StandartFile = fileData;
                db.Standarts.Add(standarts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standarts);
        }

        // GET: Standarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standarts standarts = db.Standarts.Find(id);
            if (standarts == null)
            {
                return HttpNotFound();
            }
            return View(standarts);
        }

        // POST: Standarts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StandartId,StandartName,StandartDescription,StandartFile")] Standarts standarts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standarts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standarts);
        }

        // GET: Standarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standarts standarts = db.Standarts.Find(id);
            if (standarts == null)
            {
                return HttpNotFound();
            }
            return View(standarts);
        }

        // POST: Standarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Standarts standarts = db.Standarts.Find(id);
            db.Standarts.Remove(standarts);
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
