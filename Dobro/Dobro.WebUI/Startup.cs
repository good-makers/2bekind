using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dobro.WebUI.Startup))]
namespace Dobro.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
