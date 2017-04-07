using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Infrastructure
{
    public static class UmbracoExtensions
    {
        public static IPublishedContent Homepage(this IPublishedContent content)
        {
            return content.AncestorOrSelf(1);
        }
    }
}