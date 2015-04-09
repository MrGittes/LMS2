using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScrumpingLMS.Startup))]
namespace ScrumpingLMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
