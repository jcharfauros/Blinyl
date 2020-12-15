using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blinyl.WebMVC.Startup))]
namespace Blinyl.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
