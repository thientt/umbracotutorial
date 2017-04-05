using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class SiteLayoutController : BaseController
    {
        private const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/SiteLayout/";

        public ActionResult RenderHeader()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Header.cshtml");
        }

        public ActionResult RenderFooter()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Footer.cshtml");
        }

        public ActionResult RenderIntro()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Intro.cshtml");
        }
    }
}