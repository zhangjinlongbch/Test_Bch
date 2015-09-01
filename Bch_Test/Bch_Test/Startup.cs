using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bch_Test.Startup))]
namespace Bch_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
