using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JavaScript_Unit_Tests_MVC_5.Startup))]
namespace JavaScript_Unit_Tests_MVC_5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
