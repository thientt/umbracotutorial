using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class BlogController : BaseController
    {
        public ActionResult Blog()
        {
            var model = new BlogModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}