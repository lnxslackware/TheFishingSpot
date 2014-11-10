using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheFishingSpot.Web.Startup))]
namespace TheFishingSpot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
