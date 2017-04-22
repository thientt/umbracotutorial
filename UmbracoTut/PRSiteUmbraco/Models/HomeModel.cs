using Archetype.Models;
using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using Umbraco.Core.Models;
using Umbraco.Web;

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
        }

        private static Func<IEnumerable<FeaturedItem>> GetFeaturedItems = delegate ()
         {
             var homePage = PublishedContent.Homepage();
             var featuredItems = homePage.GetPropertyValue<ArchetypeModel>(Constants.FEATURED_ITEMS);

             var _featuredItems = new List<FeaturedItem>();
             foreach (var item in featuredItems.Fieldsets)
             {
                 var imageId = item.GetValue<int>(Constants.Archetype.ALIAS_IMAGE);
                 var mediaItem = UmbracoHelper.Media(imageId);

                 int pageId = item.GetValue<int>(Constants.Archetype.ALIAS_PAGE);
                 var linkToPage = UmbracoHelper.TypedContent(pageId);

                 _featuredItems.Add(new FeaturedItem(item.GetValue<string>(Constants.Archetype.ALIAS_NAME),
                     item.GetValue<string>(Constants.Archetype.ALIAS_CATEGORY),
                     mediaItem.Url, linkToPage.Url));

             }
             return _featuredItems;
         };

        private static Func<ClientModel> GetClients = delegate ()
        {
            var homePage = PublishedContent.Homepage();
            var title = homePage.GetPropertyValue<string>(Constants.Client.CLIENT_TITLE);
            var introduction = homePage.GetPropertyValue<string>(Constants.Client.CLIENT_INTRODUCTION);

            var testimoniyItems = homePage.GetPropertyValue<ArchetypeModel>(Constants.Client.TESTIMONIES);
            var testimonies = new List<TestimonyModel>();

            foreach (var item in testimoniyItems.Fieldsets)
            {
                testimonies.Add(new TestimonyModel
                {
                    Introduction = item.GetValue(Constants.Client.TESTIMONIES_INTRODUCTION),
                    Author = item.GetValue(Constants.Client.TESTIMONIES_AUTHOR),
                    IconLink=item.GetValue(Constants.Client.TESTIMONIES_ICONLINK)
                });
            }

            return new ClientModel
            {
                TerminalTitle = title,
                TerminalIntroduction = introduction,
                Testimonies = testimonies,
            };
        };

        public Lazy<IEnumerable<FeaturedItem>> FeaturedItem
        {
            get
            {
                return new Lazy<IEnumerable<FeaturedItem>>(() =>
                {
                    return Helper.GetObjectFromCache(
                       string.Format("{0}_featureditems", CurrentCulture.Name), Constants.CACHE_TIME, GetFeaturedItems);
                });
            }
        }

        public Lazy<ClientModel> Terminal
        {
            get
            {
                return new Lazy<ClientModel>(() =>
                {
                    return Helper.GetObjectFromCache(string.Format("{0}_terminal", CurrentCulture.ThreeLetterISOLanguageName),
                        Constants.CACHE_TIME, GetClients);
                });
            }
        }
    }
}