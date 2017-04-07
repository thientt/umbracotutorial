using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class AboutController : BaseController
    {
        public ActionResult About()
        {
            var model = new AboutModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}