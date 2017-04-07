using System;
using System.Collections.Generic;
using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Core.Media;
using PRSiteUmbraco.Infrastructure;
using Archetype.Models;
using Umbraco.Web;
using System.Linq;
using Umbraco.Core.Services;
using umbraco;

namespace PRSiteUmbraco.Models
{
    public class HomeModel : BaseModel
    {
        public HomeModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public HomeModel(IPublishedContent content)
            : base(content)
        {
            var homePage = content.Homepage();
            var featuredItems = homePage.GetPropertyValue<ArchetypeModel>(Contants.FEATURED_ITEMS);

            _featuredItems = new List<FeaturedItem>();
            var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            foreach (var item in featuredItems.Fieldsets)
            {
                var imageId = item.GetValue<int>(Contants.Archetype.ALIAS_IMAGE);
                var mediaItem = umbracoHelper.Media(imageId);
                string imageUrl = mediaItem.Url;

                int pageId = item.GetValue<int>(Contants.Archetype.ALIAS_PAGE);
                var linkToPage = umbracoHelper.TypedContent(pageId);
                string linkUrl = linkToPage.Url;

                _featuredItems.Add(new FeaturedItem(item.GetValue<string>(Contants.Archetype.ALIAS_NAME),
                    item.GetValue<string>(Contants.Archetype.ALIAS_CATEGORY),
                    imageUrl, linkUrl));
            }
        }

        private List<FeaturedItem> _featuredItems;
        public Lazy<List<FeaturedItem>> FeaturedItem
        {
            get
            {
                return new Lazy<List<FeaturedItem>>(_featuredItems);
            }
        }
    }
}