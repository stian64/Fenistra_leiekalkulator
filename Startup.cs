using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fenistra.Startup))]
namespace Fenistra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
