using PRSiteUmbraco.Infrastructure;
using Umbraco.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    [Internationalization]
    public class BaseController : RenderMvcController
    {
        protected string Culture => HttpContext.Request.Cookies.Get(Constants.KEY_CULTURE)?.Value ?? Constants.DEFAULT_CULTURE;
    }
}