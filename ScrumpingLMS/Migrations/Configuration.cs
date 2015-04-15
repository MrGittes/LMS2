namespace ScrumpingLMS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ScrumpingLMS.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ScrumpingLMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ScrumpingLMS.Models.ApplicationDbContext";
        }

        protected override void Seed(ScrumpingLMS.Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if(!context.Users.Any(u => u.UserName == "Kjell"))
            {

                var user = new ApplicationUser { UserName = "Kjell" };
                manager.Create(user, "password");

                roleManager.Create(new IdentityRole { Name = "lärare" });
                manager.AddToRole(user.Id, "lärare");
            }

            if (!context.Users.Any(u => u.UserName == "Sven"))
            {

                var user2 = new ApplicationUser { UserName = "Sven" };
                manager.Create(user2, "password");

                roleManager.Create(new IdentityRole { Name = "lärare" });
                manager.AddToRole(user2.Id, "lärare");
            }

            if (!context.Users.Any(u => u.UserName == "Teacher"))
            {

                var user2 = new ApplicationUser { UserName = "Teacher" };
                manager.Create(user2, "password");

                roleManager.Create(new IdentityRole { Name = "lärare" });
                manager.AddToRole(user2.Id, "lärare");
            }


            if (!context.Users.Any(u => u.UserName == "Palle"))
            {

                var user3 = new ApplicationUser { UserName = "Palle" };
                manager.Create(user3, "password");

                roleManager.Create(new IdentityRole { Name = "lärare" });
                manager.AddToRole(user3.Id, "lärare");
            }

            if (!context.Users.Any(u => u.UserName == "student2"))
            {
                var user4 = new ApplicationUser { UserName = "student" };
                manager.Create(user4, "password");

                roleManager.Create(new IdentityRole { Name = "elev" });
                manager.AddToRole(user4.Id, "elev");
            }

            if (!context.Users.Any(u => u.UserName == "Eva"))
            {
                var user4 = new ApplicationUser { UserName = "Eva" };
                manager.Create(user4, "password");

                roleManager.Create(new IdentityRole { Name = "elev" });
                manager.AddToRole(user4.Id, "elev");
            }
        }
    }
}
