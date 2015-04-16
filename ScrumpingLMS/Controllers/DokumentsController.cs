using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScrumpingLMS.Models;
using System.IO;
using Microsoft.AspNet.Identity;


namespace ScrumpingLMS.Controllers
{
    [Authorize]
    public class DokumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dokuments
        public ActionResult Index()
        {
            var dokuments = db.Dokuments.Include(d => d.ApplicationUser);
            return View(dokuments.ToList());
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Documents/"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        // GET: Dokuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokuments.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // GET: Dokuments/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Dokuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApplicationUserId,DokumentObjekt,DokumentLink")] Dokument dokument, HttpPostedFileBase UploadTheFile)
        {

            if (UploadTheFile != null && UploadTheFile.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(UploadTheFile.FileName);
                // store the file inside ~/Content/LearnObject-Repository folder
                UploadTheFile.SaveAs(Path.Combine(Server.MapPath("~/Documents/"), fileName));
                //UploadTheFile.SaveAs("~/Documents/" + fileName);
                //var path = Path.Combine(Server.MapPath("~/Content/LearnObject-Repository"), fileName);
                //UploadTheFile.SaveAs(path);
                dokument.DokumentLink = "../../Documents/" + fileName;

            }
            var TempId = User.Identity.GetUserId();

            var _user = db.Users.Where(u => u.Id == TempId).First();

            dokument.ApplicationUserId = _user.Id;



            if (ModelState.IsValid)
            {
                db.Dokuments.Add(dokument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", dokument.ApplicationUserId);
            return View(dokument);
        }

        // GET: Dokuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokuments.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", dokument.ApplicationUserId);
            return View(dokument);
        }

        // POST: Dokuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApplicationUserId,DokumentObjekt,DokumentLink")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", dokument.ApplicationUserId);
            return View(dokument);
        }

        // GET: Dokuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokuments.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // POST: Dokuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dokument dokument = db.Dokuments.Find(id);
            db.Dokuments.Remove(dokument);
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
