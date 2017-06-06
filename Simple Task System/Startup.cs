using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simple_Task_System.Startup))]
namespace Simple_Task_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
