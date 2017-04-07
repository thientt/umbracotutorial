using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class ServicesController : BaseController
    {
        public ActionResult Services()
        {
            var model = new ServicesModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}