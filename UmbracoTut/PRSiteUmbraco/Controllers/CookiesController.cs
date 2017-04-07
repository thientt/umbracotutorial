using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class CookiesController : BaseController
    {
        public ActionResult Cookies()
        {
            var model = new CookieModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}