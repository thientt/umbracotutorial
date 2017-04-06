using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PRSiteUmbraco.Infrastructure
{
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            const string key = "_culture";
            const string clutureDefault = "en";
            string culture = clutureDefault;

            var segments = filterContext.HttpContext.Request.Url.Segments;
            if (segments != null && segments.Any() && segments.Count() > 1)
                culture = segments[1].Replace("/", "");
            filterContext.HttpContext.Request.Cookies.Set(new HttpCookie(key, culture));

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        }
    }
}