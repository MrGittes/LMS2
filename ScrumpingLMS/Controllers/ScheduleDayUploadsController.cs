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
using System.IO;


namespace ScrumpingLMS.Controllers
{
    public class ScheduleDayUploadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleDayUploads
        public ActionResult Index()
        {
            var scheduleDayUploads = db.ScheduleDayUploads.Include(s => s.Klass);
            return View(scheduleDayUploads.ToList());
        }

        // GET: ScheduleDayUploads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDayUpload scheduleDayUpload = db.ScheduleDayUploads.Find(id);
            if (scheduleDayUpload == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDayUpload);
        }

        // GET: ScheduleDayUploads/Create
       
        // POST: ScheduleDayUploads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        // GET: ScheduleDayUploads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDayUpload scheduleDayUpload = db.ScheduleDayUploads.Find(id);
            if (scheduleDayUpload == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", scheduleDayUpload.KlassId);
            return View(scheduleDayUpload);
        }
        public ActionResult Create()
        {
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name");
            return View();
        }

        // POST: ScheduleDayUploads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DayNumber,KlassId,LinkToDokument")] ScheduleDayUpload scheduleDayUpload, HttpPostedFileBase UploadTheFile)
        {
            if (UploadTheFile != null && UploadTheFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(UploadTheFile.FileName);
                UploadTheFile.SaveAs(Path.Combine(Server.MapPath("~/Documents/"), fileName));
                scheduleDayUpload.LinkToDokument = "../../Documents/" + fileName;
                //Console.WriteLine(Path.GetDirectoryName(fileName));
                var fileNamePath = Path.GetDirectoryName(fileName);
               

            }
            if (ModelState.IsValid)
            {
                db.ScheduleDayUploads.Add(scheduleDayUpload);
                db.SaveChanges();
                return RedirectToAction("Index");

                //db.Entry(scheduleDayUpload).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", scheduleDayUpload.KlassId);
            return View(scheduleDayUpload);
        }

        // GET: ScheduleDayUploads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDayUpload scheduleDayUpload = db.ScheduleDayUploads.Find(id);
            if (scheduleDayUpload == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDayUpload);
        }

        // POST: ScheduleDayUploads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleDayUpload scheduleDayUpload = db.ScheduleDayUploads.Find(id);
            db.ScheduleDayUploads.Remove(scheduleDayUpload);
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

        public ActionResult ShowFile(string sLinkToDokument)
        {
            //sLinkToDokument = "Documents/318278_3424286525069_1067955126_n.png";

            var pathh = "C:/Users/User/Documents/Visual Studio 2013/Projects/NewRepo2/ScrumpingLMS/";

            var storfil = pathh + sLinkToDokument;

            //storfil = "C:\\Users\\User\\Downloads\\1134x378-top.png";


            String strNew = sLinkToDokument.Replace("~", string.Empty);
            //var fileName = Path.GetFileName(sLinkToDokument);
            System.Diagnostics.Process.Start(storfil);
            return View();
        }
    }
}
