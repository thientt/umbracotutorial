using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class HomeController : BaseController
    {
        private const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Home/";

        public ActionResult RenderFeaturedSection()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Featured.cshtml");
        }

        public ActionResult RenderServicesSection()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Services.cshtml");
        }

        public ActionResult RenderBlogSection()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Blog.cshtml");
        }

        public ActionResult RenderClientSection()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Client.cshtml");
        }
    }
}