using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCL.MVC.Week6.Day1.Startup))]
namespace HCL.MVC.Week6.Day1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
