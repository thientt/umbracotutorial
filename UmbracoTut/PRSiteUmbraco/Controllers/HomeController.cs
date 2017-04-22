﻿using PRSiteUmbraco.Models;
using System.Web.Mvc;

namespace PRSiteUmbraco.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Home()
        {
            var model = new HomeModel(CurrentPage);
            return CurrentTemplate(model);
        }
    }
}