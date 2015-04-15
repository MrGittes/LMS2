using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace ScrumpingLMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexLoginRoute()
        {
            var tempId = User.Identity.GetUserId();
            var roleID = db.Users.Where(u => u.Id == tempId).First().Roles.First().RoleId;
            var adminID = db.Roles.Where(r => r.Name == "lärare").First().Id;

            if (roleID == adminID)
            {
                return RedirectToAction("Index", "Klasses");
            }
            else
            {
                return RedirectToAction("Index", "ScheduleDays");
            }
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}