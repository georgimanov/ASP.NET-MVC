using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportSystem.Web.Startup))]
namespace SportSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
