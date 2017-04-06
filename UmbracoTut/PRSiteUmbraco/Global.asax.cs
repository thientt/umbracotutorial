using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PRSiteUmbraco.Infrastructure;

namespace PRSiteUmbraco
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Set culture
            ControllerBuilder.Current.SetControllerFactory(
                new DefaultControllerFactory(new CultureAwareControllerActivator()));
        }
    }
}