using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;

namespace PRSiteUmbraco.Infrastructure
{
    public static class UmbracoExtensions
    {
        public static IPublishedContent Homepage(this IPublishedContent content)
        {
            return content.GetPage(Constants.Page.HOME_PAGE_DOC_TYPE_ALIAS);
        }

        public static IPublishedContent BlogPage(this IPublishedContent content)
        {
            return content.GetPage(Constants.Page.BLOG_PAGE_DOC_TYPE_ALIAS);
        }

        public static IPublishedContent GetPage(this IPublishedContent content, string nameAliasPage)
        {
            return content.AncestorOrSelf(1).DescendantsOrSelf().FirstOrDefault(x => x.DocumentTypeAlias == nameAliasPage);
        }
    }
}