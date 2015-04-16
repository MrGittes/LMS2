using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScrumpingLMS.Models;
using Microsoft.AspNet.Identity;

namespace ScrumpingLMS.Controllers
{
    public class KlassApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KlassApplicationUsers
        public ActionResult Index()
        {
            var klassApplicationUsers = db.KlassApplicationUsers.Include(k => k.ApplicationUser).Include(k => k.Klass);
            return View(klassApplicationUsers.ToList());
        }

        // GET: KlassApplicationUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlassApplicationUser klassApplicationUser = db.KlassApplicationUsers.Find(id);
            if (klassApplicationUser == null)
            {
                return HttpNotFound();
            }
            return View(klassApplicationUser);
        }

        // GET: KlassApplicationUsers/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name");
            return View();
        }

        // POST: KlassApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,KlassId")] KlassApplicationUser klassApplicationUser)
        {
            if (ModelState.IsValid)
            {
                db.KlassApplicationUsers.Add(klassApplicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

//            var teachers = db.Users.Where(t => t.Roles);

//            var roleID = db.Users.Where(u => u.Id == tempId).First().Roles.First().RoleId;

 //           var adminID = db.Roles.Where(r => r.Name == "lärare").First().Id;

 //           var list = db.Users.ToList().Where(x => UserManager.IsInRole(x.Id, "Lärare")).ToList();
            var list = db.Users.ToList().Where(x => x.Roles.Contains("Lärare")).ToList();
            var teachers = db.Users;

            ViewBag.ApplicationUserId = new SelectList(teachers, "Id", "FirstName", klassApplicationUser.ApplicationUserId);
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", klassApplicationUser.KlassId);
            return View(klassApplicationUser);
        }

        // GET: KlassApplicationUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlassApplicationUser klassApplicationUser = db.KlassApplicationUsers.Find(id);
            if (klassApplicationUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", klassApplicationUser.ApplicationUserId);
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", klassApplicationUser.KlassId);
            return View(klassApplicationUser);
        }

        // POST: KlassApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,KlassId")] KlassApplicationUser klassApplicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klassApplicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", klassApplicationUser.ApplicationUserId);
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", klassApplicationUser.KlassId);
            return View(klassApplicationUser);
        }

        // GET: KlassApplicationUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KlassApplicationUser klassApplicationUser = db.KlassApplicationUsers.Find(id);
            if (klassApplicationUser == null)
            {
                return HttpNotFound();
            }
            return View(klassApplicationUser);
        }

        // POST: KlassApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KlassApplicationUser klassApplicationUser = db.KlassApplicationUsers.Find(id);
            db.KlassApplicationUsers.Remove(klassApplicationUser);
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
