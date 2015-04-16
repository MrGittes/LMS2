using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScrumpingLMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentDay { get; set; }
        public int KlassId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Dokument> Dokuments { get; set; }
        public DbSet<DokumentScheduleDay> DokumentSchedukeDays { get; set; }
        public DbSet<Klass> Klasser { get; set; }
        public DbSet<KlassApplicationUser> KlassApplicationUsers { get; set; }

        public DbSet<ScheduleDay> ScheduleDays { get; set; }
        public DbSet<SharedFolder> SharedFolders { get; set; }
        public DbSet<SharedFolderApplicationUser> SharedFolderApplicationUsers { get; set; }
        public DbSet<ScheduleDayUpload> ScheduleDayUploads { get; set; }
        //public System.Data.Entity.DbSet<ScrumpingLMS.Models.ScheduleDayUpload> ScheduleDayUploads { get; set; }

       // public System.Data.Entity.DbSet<ScrumpingLMS.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<ScrumpingLMS.Models.ApplicationUser> ApplicationUsers { get; set; }

//        public System.Data.Entity.DbSet<ScrumpingLMS.Models.ApplicationUser> ApplicationUsers { get; set; }

    }


}