﻿using System;
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
    public class SubdivisionsController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Subdivisions
        public ActionResult Index()
        {
            return View(db.Subdivisions.ToList());
        }

        // GET: Subdivisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivisions subdivisions = db.Subdivisions.Find(id);
            if (subdivisions == null)
            {
                return HttpNotFound();
            }
            return View(subdivisions);
        }

        // GET: Subdivisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subdivisions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubdivisionId,SubdivisionName")] Subdivisions subdivisions)
        {
            if (ModelState.IsValid)
            {
                db.Subdivisions.Add(subdivisions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subdivisions);
        }

        // GET: Subdivisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivisions subdivisions = db.Subdivisions.Find(id);
            if (subdivisions == null)
            {
                return HttpNotFound();
            }
            return View(subdivisions);
        }

        // POST: Subdivisions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubdivisionId,SubdivisionName")] Subdivisions subdivisions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subdivisions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subdivisions);
        }

        // GET: Subdivisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivisions subdivisions = db.Subdivisions.Find(id);
            if (subdivisions == null)
            {
                return HttpNotFound();
            }
            return View(subdivisions);
        }

        // POST: Subdivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subdivisions subdivisions = db.Subdivisions.Find(id);
            db.Subdivisions.Remove(subdivisions);
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
