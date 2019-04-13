using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Haber.Web.Startup))]
namespace Haber.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
