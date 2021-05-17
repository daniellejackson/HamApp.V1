using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HamApp.V1.Startup))]
namespace HamApp.V1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
