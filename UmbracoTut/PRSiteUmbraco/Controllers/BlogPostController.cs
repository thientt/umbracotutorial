using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class BlogPostController : BaseController
    {
        public ActionResult BlogPost()
        {
            var model = new BlogPostModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}