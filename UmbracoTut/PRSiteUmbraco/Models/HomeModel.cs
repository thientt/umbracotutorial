using Archetype.Models;
using PRSiteUmbraco.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class HomeModel : BaseModel
    {
        private static IPublishedContent PublishedContent;

        public HomeModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
            PublishedContent = content;
        }

        public HomeModel(IPublishedContent content)
            : base(content)
        {
            PublishedContent = content;
            //var homePage = content.Homepage();
            //var featuredItems = homePage.GetPropertyValue<ArchetypeModel>(Contants.FEATURED_ITEMS);

            //var _featuredItems = new List<FeaturedItem>();
            //var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            //foreach (var item in featuredItems.Fieldsets)
            //{
            //    var imageId = item.GetValue<int>(Contants.Archetype.ALIAS_IMAGE);
            //    var mediaItem = umbracoHelper.Media(imageId);
            //    string imageUrl = mediaItem.Url;

            //    int pageId = item.GetValue<int>(Contants.Archetype.ALIAS_PAGE);
            //    var linkToPage = umbracoHelper.TypedContent(pageId);
            //    string linkUrl = linkToPage.Url;

            //    _featuredItems.Add(new FeaturedItem(item.GetValue<string>(Contants.Archetype.ALIAS_NAME),
            //        item.GetValue<string>(Contants.Archetype.ALIAS_CATEGORY),
            //        imageUrl, linkUrl));

            //    this._featuredItems = _featuredItems;
            //}
        }

        Func<IEnumerable<FeaturedItem>> GetFeaturedItems = delegate ()
        {
            var homePage = PublishedContent.Homepage();
            var featuredItems = homePage.GetPropertyValue<ArchetypeModel>(Contants.FEATURED_ITEMS);

            var _featuredItems = new List<FeaturedItem>();
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
            return _featuredItems;
        };

        //private IEnumerable<FeaturedItem> _featuredItems;
        public Lazy<IEnumerable<FeaturedItem>> FeaturedItem
        {
            get
            {
                return new Lazy<IEnumerable<FeaturedItem>>(() =>
                {
                    return Helper.GetObjectFromCache<IEnumerable<FeaturedItem>>(
                       string.Format("{0}_featureditems", CurrentCulture.Name), Contants.CACHE_TIME, GetFeaturedItems);
                });
            }
        }
    }
}