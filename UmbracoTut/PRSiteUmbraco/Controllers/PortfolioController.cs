using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class PortfolioController : BaseController
    {
        public ActionResult Portfolio()
        {
            var model = new PortfolioModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}