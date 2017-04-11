using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;

namespace PRSiteUmbraco.Infrastructure
{
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///     Aliases of doctypes that should be excluded from navigation etc.
        /// </summary>
        private static readonly string[] ValidLanguages =
        {
            "en",
            "vi",
            "jp"
        };

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cultureName = string.Empty;

            if (!UmbracoContext.Current.IsFrontEndUmbracoRequest) return;
            if (filterContext.HttpContext.Request.IsAjaxRequest()) return;
            if (filterContext.HttpContext.Request.Url != null)
            {
                var segments = filterContext.HttpContext.Request.Url.Segments;
                cultureName = (filterContext.HttpContext.Request.Url != null
                               && segments.Any()
                               && segments.Length > 1
                               && !string.IsNullOrEmpty(segments[1]))
                    ? segments[1].Replace("/", "").ToLower()
                    : ValidLanguages[0];
            }

            if (!ValidLanguages.Contains(cultureName))
                cultureName = ValidLanguages[0];

            // Attempt to read the culture cookie from Request
            var cultureCookie = filterContext.HttpContext.Request.Cookies[Constants.KEY_CULTURE] ?? new HttpCookie(Constants.KEY_CULTURE);

            var currentUrl = string.Empty;
            //check in the URL has cluture or not
            if (filterContext.HttpContext.Request.Url?.Segments.Length > 1
                && !ValidLanguages.Contains(filterContext.HttpContext.Request.Url?.Segments[1].Trim('/').ToLower()))
                currentUrl = string.Format("/{0}{1}", cultureName, filterContext.HttpContext.Request.Url?.AbsolutePath);

            if (filterContext.HttpContext.Request.Url != null
                && !string.IsNullOrEmpty(cultureCookie.Value)
                && cultureName.Equals(cultureCookie.Value, StringComparison.InvariantCultureIgnoreCase)
                && filterContext.HttpContext.Request.Url.Segments.Length > 1
                && !string.IsNullOrEmpty(currentUrl))
            {
                filterContext.Result = new RedirectResult(currentUrl);
                return;
            }

            if ((filterContext.HttpContext.Request.Url?.Segments.Length < 2 ||
                 string.IsNullOrEmpty(filterContext.HttpContext.Request.Url?.Segments[1]))
                && !string.IsNullOrEmpty(cultureCookie.Value))
                cultureName = cultureCookie.Value;


            //Add Cookie to response
            cultureCookie.Value = cultureName.ToLower();
            cultureCookie.Expires = DateTime.Now.AddYears(1);
            filterContext.HttpContext.Response.Cookies.Add(cultureCookie);

            if (filterContext.HttpContext.Request.Url?.Segments.Length < 2
                || !ValidLanguages.Contains(filterContext.HttpContext.Request.Url?.Segments[1].Trim('/').ToLower()))
                filterContext.Result = string.IsNullOrEmpty(currentUrl)
                    ? new RedirectResult(string.Format("/{0}/", cultureName))
                    : new RedirectResult(currentUrl);

            //Set Current Culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(cultureName);
        }
    }
}