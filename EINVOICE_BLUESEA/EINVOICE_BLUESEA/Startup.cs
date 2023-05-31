using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EINVOICE_BLUESEA.Startup))]
namespace EINVOICE_BLUESEA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
