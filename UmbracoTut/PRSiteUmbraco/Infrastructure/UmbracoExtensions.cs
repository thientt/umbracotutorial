using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;

namespace PRSiteUmbraco.Infrastructure
{
    public static class UmbracoExtensions
    {
        public static IPublishedContent Homepage(this IPublishedContent content)
        {
            const string HOME_PAGE_DOC_TYPE_ALIAS = "home";
            return content.AncestorOrSelf(1).DescendantsOrSelf().FirstOrDefault(x => x.DocumentTypeAlias == HOME_PAGE_DOC_TYPE_ALIAS);
        }
    }
}