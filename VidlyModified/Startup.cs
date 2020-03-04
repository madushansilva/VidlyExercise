using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyModified.Startup))]
namespace VidlyModified
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
