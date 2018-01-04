using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Helperservices.Startup))]
namespace Helperservices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
