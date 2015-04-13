using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScrumpingLMS.Models;

namespace ScrumpingLMS.Controllers
{
    public class SharedFoldersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SharedFolders
        public ActionResult Index()
        {
            var sharedFolders = db.SharedFolders.Include(s => s.ApplicationUser);
            return View(sharedFolders.ToList());
        }

        // GET: SharedFolders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SharedFolder sharedFolder = db.SharedFolders.Find(id);
            if (sharedFolder == null)
            {
                return HttpNotFound();
            }
            return View(sharedFolder);
        }

        // GET: SharedFolders/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: SharedFolders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ApplicationUserId,LinkToDokument")] SharedFolder sharedFolder)
        {
            if (ModelState.IsValid)
            {
                db.SharedFolders.Add(sharedFolder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", sharedFolder.ApplicationUserId);
            return View(sharedFolder);
        }

        // GET: SharedFolders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SharedFolder sharedFolder = db.SharedFolders.Find(id);
            if (sharedFolder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", sharedFolder.ApplicationUserId);
            return View(sharedFolder);
        }

        // POST: SharedFolders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ApplicationUserId,LinkToDokument")] SharedFolder sharedFolder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sharedFolder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", sharedFolder.ApplicationUserId);
            return View(sharedFolder);
        }

        // GET: SharedFolders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SharedFolder sharedFolder = db.SharedFolders.Find(id);
            if (sharedFolder == null)
            {
                return HttpNotFound();
            }
            return View(sharedFolder);
        }

        // POST: SharedFolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SharedFolder sharedFolder = db.SharedFolders.Find(id);
            db.SharedFolders.Remove(sharedFolder);
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
