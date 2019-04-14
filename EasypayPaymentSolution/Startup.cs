using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasypayPaymentSolution.Startup))]
namespace EasypayPaymentSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
