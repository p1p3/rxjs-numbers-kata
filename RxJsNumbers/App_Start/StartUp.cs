using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RxJsNumbers.App_Start.Startup))]
namespace RxJsNumbers.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }

    }

}