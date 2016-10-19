using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirportPanelApplication.Startup))]
namespace AirportPanelApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
