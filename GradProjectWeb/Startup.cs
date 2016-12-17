using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GradProjectWeb.Startup))]
namespace GradProjectWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
