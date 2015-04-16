using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScrumpingLMS.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using System.IO;

namespace ScrumpingLMS.Controllers
{
    public class ScheduleDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ScheduleDays
        public ActionResult Index()
        {
            List<ScheduleDay> days = new List<ScheduleDay>();

            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name");

            var tempId = User.Identity.GetUserId();
            var roleID = db.Users.Where(u => u.Id == tempId).First().Roles.First().RoleId;
            var adminID = db.Roles.Where(r => r.Name == "admin").First().Id;

            if (roleID == adminID)
            {
                var scheduleDays = db.ScheduleDays.Include(s => s.Klass);
                return View(scheduleDays.ToList());
            }
            else
            {
                var _user = db.Users.Where(u => u.Id == tempId).First();

                Klass klass = db.Klasser.Find(_user.KlassId);
                ViewBag.KlassNamn = klass.Name;

                var scheduleDays = db.ScheduleDays
                    .Where(k => k.KlassId == _user.KlassId);

                return View(scheduleDays.ToList());
            }
        }
        public ActionResult Upload([Bind(Include = "Id,DayNumber,KlassId,Details,WorkingDate,LinkToDokument")] ScheduleDay scheduleDay, HttpPostedFileBase UploadTheFile)
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
                scheduleDay.LinkToDokument = "~/Documents/" + fileName;

            }
            if (ModelState.IsValid)
            {

                //if (scheduleDay.Details.Contains("script"))
                //{
                //    scheduleDay.Details = scheduleDay.Details.Replace("script", "scripting is not allowed");
                //}

                db.ScheduleDays.Add(scheduleDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", scheduleDay.KlassId);
            return View(scheduleDay);
            
        }

        // GET: ScheduleDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDay scheduleDay = db.ScheduleDays.Find(id);
            if (scheduleDay == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDay);
        }

      
 

        // GET: ScheduleDays/Create
        public ActionResult Create()
        {
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name");
            return View();
        }

        // POST: ScheduleDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DayNumber,KlassId,Details,WorkingDate,LinkToDokument")] ScheduleDay scheduleDay, HttpPostedFileBase UploadTheFile)
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
                scheduleDay.LinkToDokument = "~/Documents/" + fileName;

            }
            scheduleDay.Details = "---";
            


            if (ModelState.IsValid)
            {

                if (scheduleDay.Details.Contains("script"))
                {
                    scheduleDay.Details = scheduleDay.Details.Replace("script", "scripting is not allowed");
                }

                db.ScheduleDays.Add(scheduleDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", scheduleDay.KlassId);
            return View(scheduleDay);
        }

        // GET: ScheduleDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDay scheduleDay = db.ScheduleDays.Find(id);
            if (scheduleDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", scheduleDay.KlassId);
            return View(scheduleDay);
        }

        // POST: ScheduleDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DayNumber,KlassId,Details,WorkingDate,LinkToDokument")] ScheduleDay scheduleDay, HttpPostedFileBase UploadTheFile)
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
                scheduleDay.LinkToDokument = "~/Documents/" + fileName;

            }
            if (ModelState.IsValid)
            {

                if (scheduleDay.Details.Contains("script"))
                {
                    scheduleDay.Details = scheduleDay.Details.Replace("script", "scripting is not allowed");
                }
                
                db.Entry(scheduleDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlassId = new SelectList(db.Klasser, "Id", "Name", scheduleDay.KlassId);
            return View(scheduleDay);
        }

        // GET: ScheduleDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDay scheduleDay = db.ScheduleDays.Find(id);
            if (scheduleDay == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDay);
        }

        // POST: ScheduleDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleDay scheduleDay = db.ScheduleDays.Find(id);
            db.ScheduleDays.Remove(scheduleDay);
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
