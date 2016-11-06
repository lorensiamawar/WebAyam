using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAyam.Startup))]
namespace WebAyam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
