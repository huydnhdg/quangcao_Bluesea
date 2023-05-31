using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemSMS.Startup))]
namespace TemSMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
