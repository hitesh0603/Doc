using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalDemo_MVC.Startup))]
namespace FinalDemo_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
