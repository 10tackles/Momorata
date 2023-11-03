using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Momorata.WebUI.Startup))]
namespace Momorata.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
