using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuditControlSystem.Models;
using System.IO;

namespace AuditControlSystem.Controllers
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
            Standart standart = db.Standarts.Find(id);
            if (standart == null)
            {
                return HttpNotFound();
            }
            return View(standart);
        }

        // GET: Standarts/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Standarts/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "StandartId,StandartName,StandartDescription,StandartFileName")] Standart standart, HttpPostedFileBase uploadFile)
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
                standart.StandartFile = fileData;

                db.Standarts.Add(standart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standart);
        }

        // GET: Standarts/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standart standart = db.Standarts.Find(id);
            if (standart == null)
            {
                return HttpNotFound();
            }
            return View(standart);
        }

        // POST: Standarts/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "StandartId,StandartName,StandartDescription,StandartFileName")] Standart standart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standart);
        }

        // GET: Standarts/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standart standart = db.Standarts.Find(id);
            if (standart == null)
            {
                return HttpNotFound();
            }
            return View(standart);
        }

        // POST: Standarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Standart standart = db.Standarts.Find(id);
            db.Standarts.Remove(standart);
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
