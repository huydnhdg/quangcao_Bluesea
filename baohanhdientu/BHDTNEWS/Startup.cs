using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BHDTNEWS.Startup))]
namespace BHDTNEWS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
