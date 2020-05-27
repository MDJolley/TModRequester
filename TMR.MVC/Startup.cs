using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TMR.MVC.Startup))]
namespace TMR.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
