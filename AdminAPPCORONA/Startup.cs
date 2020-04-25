using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HOSPBAPP.Startup))]
namespace HOSPBAPP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
