using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eManager.Web.Startup))]
namespace eManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
