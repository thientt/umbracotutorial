using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class SiteLayoutController : BaseController
    {
        public ActionResult RenderHeader()
        {
            return PartialView("~/Views/Partials/SiteLayout/Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView("~/Views/Partials/SiteLayout/Footer.cshtml");
        }
    }
}