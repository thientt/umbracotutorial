using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class HomeController : BaseController
    {
        private const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Home/";

        public ActionResult Home()
        {
            var model = new HomeModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}