using InternalAuditSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.RoleList = new SelectList(db.Roles, "RoleId", "Role");
            ViewBag.SubdivisionList = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName");
            return View();
        }

        // POST: User/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,SubdivisionId,Role,UserLastName,UserName,UserMiddleName,UserEmail,UserPhone")] Users users)
        {
            //ViewBag.SubdivisionList = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", users.SubdivisionId);
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", users.SubdivisionId);
            return View(users);
        }

        // POST: User/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,SubdivisionId,Role,UserLastName,UserName,UserMiddleName,UserEmail,UserPhone")] Users users)
        {
            ViewBag.SubdivisionId = new SelectList(db.Subdivisions, "SubdivisionId", "SubdivisionName", users.SubdivisionId);
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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
