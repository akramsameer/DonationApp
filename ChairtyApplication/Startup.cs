using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChairtyApplication.Startup))]
namespace ChairtyApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
