using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Archetype.Models;
using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class HomeModel : BaseModel
    {
        private readonly Func<IEnumerable<FeaturedItem>> GetFeaturedItems = delegate
        {
            var homePage = PublishedContent.Homepage();
            var featuredItems = homePage.GetPropertyValue<ArchetypeModel>(Constants.FEATURED_ITEMS);

            return (from item in featuredItems.Fieldsets.Where(x => !x.Disabled)
                let imageId = item.GetValue<int>(Constants.Archetype.ALIAS_IMAGE)
                let mediaItem = UmbracoHelper.Media(imageId)
                let imageUrl = mediaItem.Url
                let pageId = item.GetValue<int>(Constants.Archetype.ALIAS_PAGE)
                let linkToPage = UmbracoHelper.TypedContent(pageId)
                let linkUrl = linkToPage.Url
                select new FeaturedItem(item.GetValue<string>(Constants.Archetype.ALIAS_NAME),
                    item.GetValue<string>(Constants.Archetype.ALIAS_CATEGORY),
                    (string) imageUrl,
                    linkUrl));
        };

        public HomeModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public HomeModel(IPublishedContent content)
            : base(content)
        {
        }

        public Lazy<IEnumerable<FeaturedItem>> FeaturedItem
        {
            get
            {
                return new Lazy<IEnumerable<FeaturedItem>>(() => Helper.GetObjectFromCache(
                    string.Format("{0}_featureditems", CurrentCulture.Name), Constants.CACHE_TIME, GetFeaturedItems));
            }
        }
    }
}