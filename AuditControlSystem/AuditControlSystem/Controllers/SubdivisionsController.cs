﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuditControlSystem.Models;

namespace AuditControlSystem.Controllers
{
    public class SubdivisionsController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Subdivisions
        public ActionResult Index()
        {
            return View(db.Subdivisions);
        }

        // GET: Subdivisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivision subdivision = db.Subdivisions.Find(id);
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
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
        public ActionResult Create([Bind(Include = "SubdivisionId,SubdivisionName")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                db.Subdivisions.Add(subdivision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subdivision);
        }

        // GET: Subdivisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivision subdivision = db.Subdivisions.Find(id);
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
        }

        // POST: Subdivisions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubdivisionId,SubdivisionName")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subdivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subdivision);
        }

        // GET: Subdivisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subdivision subdivision = db.Subdivisions.Find(id);
            if (subdivision == null)
            {
                return HttpNotFound();
            }
            return View(subdivision);
        }

        // POST: Subdivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subdivision subdivision = db.Subdivisions.Find(id);
            db.Subdivisions.Remove(subdivision);
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