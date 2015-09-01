using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCH_MVC.Startup))]
namespace BCH_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
