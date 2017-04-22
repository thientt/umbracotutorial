using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;

namespace PRSiteUmbraco.Infrastructure
{
    public static class UmbracoExtensions
    {
        public static IPublishedContent Homepage(this IPublishedContent content)
        {
            return content.GetPage(Constants.Page.ALIAS_HOME);
        }

        public static IPublishedContent Blogpage(this IPublishedContent content)
        {
            return content.GetPage(Constants.Page.ALIAS_BLOG);
        }

        public static IPublishedContent GetPage(this IPublishedContent content, string aliasPage)
        {
            return content.AncestorOrSelf(1).DescendantsOrSelf().FirstOrDefault(x => x.DocumentTypeAlias == aliasPage);
        }
    }
}