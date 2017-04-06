using PRSiteUmbraco.Infrastructure;
using Umbraco.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    [Internationalization]
    public class BaseController : SurfaceController
    {
        protected string Culture
        {
            get
            {
                return HttpContext.Request.Cookies.Get("_culture").Value ?? "en";
            }
        }
    }
}