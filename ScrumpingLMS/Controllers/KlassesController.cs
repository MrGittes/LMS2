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
    [Authorize]
    public class KlassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Klasses
        public ActionResult Index()
        {
            return View(db.Klasser.ToList());
        }

        // GET: Klasses
        //        public async Task<ActionResult> IndexKlass()
        public ActionResult IndexKlass()
        {
            var TempId = User.Identity.GetUserId();


            var _user = db.Users.Where(u => u.Id == TempId).First();         
            var Deltagare = db.Users
                .Where(i => i.KlassId == _user.KlassId).ToList();

            return View(Deltagare);
        }

        // GET: Klasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klass klass = db.Klasser.Find(id);
            if (klass == null)
            {
                return HttpNotFound();
            }
            var students = db.Users.Where(i => i.KlassId == klass.Id).ToList();

            ViewBag.LMSStudents = students;
 
            return View(klass);
        }

        // GET: Klasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,NumberOfDays")] Klass klass)
        {
            if (ModelState.IsValid)
            {
                db.Klasser.Add(klass);
                db.SaveChanges();
                int newID = klass.Id;

                ScheduleDay day = new ScheduleDay();
                day.KlassId = klass.Id;
                day.Details = "";

                for (int i = 1; i <= klass.NumberOfDays; i++)
                {
                    day.DayNumber = i;
                    db.ScheduleDays.Add(day);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(klass);
        }

        // GET: Klasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klass klass = db.Klasser.Find(id);
            if (klass == null)
            {
                return HttpNotFound();
            }
            return View(klass);
        }

        // POST: Klasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,NumberOfDays")] Klass klass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klass);
        }

        // GET: Klasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klass klass = db.Klasser.Find(id);
            if (klass == null)
            {
                return HttpNotFound();
            }
            return View(klass);
        }

        // POST: Klasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klass klass = db.Klasser.Find(id);
            db.Klasser.Remove(klass);
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
