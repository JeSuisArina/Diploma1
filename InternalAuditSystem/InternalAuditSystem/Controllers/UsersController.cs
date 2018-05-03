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
    public class UsersController : Controller
    {
        private AuditContext db = new AuditContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.UsersView.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersView usersView = db.UsersView.Find(id);
            if (usersView == null)
            {
                return HttpNotFound();
            }
            return View(usersView);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserLastName,UserName,UserEmail,UserPhone,SubdivisionName,UserId,Role,UserMiddleName")] UsersView usersView)
        {
            if (ModelState.IsValid)
            {
                db.UsersView.Add(usersView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usersView);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersView usersView = db.UsersView.Find(id);
            if (usersView == null)
            {
                return HttpNotFound();
            }
            return View(usersView);
        }

        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserLastName,UserName,UserEmail,UserPhone,SubdivisionName,UserId,Role,UserMiddleName")] UsersView usersView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usersView);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersView usersView = db.UsersView.Find(id);
            if (usersView == null)
            {
                return HttpNotFound();
            }
            return View(usersView);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UsersView usersView = db.UsersView.Find(id);
            db.UsersView.Remove(usersView);
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
