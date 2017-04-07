using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class ContactController : BaseController
    {
        public ActionResult Contact()
        {
            var model = new ContactModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}