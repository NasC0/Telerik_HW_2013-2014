using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_01.FirstMVCApp.Startup))]
namespace _01.FirstMVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
