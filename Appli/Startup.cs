using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Appli.Startup))]
namespace Appli
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
