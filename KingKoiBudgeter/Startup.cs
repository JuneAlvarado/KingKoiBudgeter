using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KingKoiBudgeter.Startup))]
namespace KingKoiBudgeter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
