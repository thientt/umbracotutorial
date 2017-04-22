using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Archetype.Models;
using PRSiteUmbraco.Entities;
using PRSiteUmbraco.Infrastructure;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class HomeModel : BaseModel
    {
        private static readonly Func<IEnumerable<FeaturedItem>> GetFeaturedItems = delegate
        {
            var homePage = PublishedContent.Homepage();
            var featuredItems = homePage.GetPropertyValue<ArchetypeModel>(Constants.FEATURED_ITEMS);

            return (from item in featuredItems.Fieldsets
                let imageId = item.GetValue<int>(Constants.Archetype.ALIAS_IMAGE)
                let mediaItem = UmbracoHelper.Media(imageId)
                let pageId = item.GetValue<int>(Constants.Archetype.ALIAS_PAGE)
                let linkToPage = UmbracoHelper.TypedContent(pageId)
                select new FeaturedItem(item.GetValue<string>(Constants.Archetype.ALIAS_NAME),
                    item.GetValue<string>(Constants.Archetype.ALIAS_CATEGORY),
                    mediaItem.Url, linkToPage.Url)).ToList();
        };

        private static readonly Func<ClientModel> GetClients = delegate
        {
            var homePage = PublishedContent.Homepage();
            var title = homePage.GetPropertyValue<string>(Constants.Client.CLIENT_TITLE);
            var introduction = homePage.GetPropertyValue<string>(Constants.Client.CLIENT_INTRODUCTION);

            var testimoniyItems = homePage.GetPropertyValue<ArchetypeModel>(Constants.Client.TESTIMONIES);
            var testimonies = testimoniyItems.Fieldsets.Select(item => new TestimonyModel
            {
                Introduction = item.GetValue(Constants.Client.TESTIMONIES_INTRODUCTION),
                Author = item.GetValue(Constants.Client.TESTIMONIES_AUTHOR),
                IconLink = item.GetValue(Constants.Client.TESTIMONIES_ICONLINK)
            }).ToList();

            return new ClientModel
            {
                TerminalTitle = title,
                TerminalIntroduction = introduction,
                Testimonies = testimonies
            };
        };

        public HomeModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public HomeModel(IPublishedContent content)
            : base(content)
        {
        }

        public IEnumerable<FeaturedItem> FeaturedItem => Helper.GetObjectFromCache(
            string.Format("{0}_featureditems", CurrentCulture.Name), Constants.CACHE_TIME, GetFeaturedItems);

        public ClientModel Terminal => Helper.GetObjectFromCache(
            string.Format("{0}_terminal", CurrentCulture.ThreeLetterISOLanguageName),
            Constants.CACHE_TIME, GetClients);
    }
}