using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FBAndGoogleLogin.Startup))]
namespace FBAndGoogleLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
