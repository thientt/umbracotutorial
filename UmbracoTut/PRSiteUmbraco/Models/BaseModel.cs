using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace PRSiteUmbraco.Models
{
    public class BaseModel : RenderModel
    {
        protected static IPublishedContent PublishedContent;
        protected static UmbracoHelper UmbracoHelper;

        public BaseModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
            PublishedContent = content;
            UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
        }

        public BaseModel(IPublishedContent content)
            : base(content)
        {
            PublishedContent = content;
            UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            MetaData = GetMeta();
            NavigationLinkItem = GetNavigationModelFromDatabase(content);
        }

        #region Properties

        public List<NavigationListItem> NavigationLinkItem { get; private set; }

        public MetaData MetaData => GetMeta();

        #endregion

        #region Private

        private static MetaData GetMeta()
        {
            var homePage = PublishedContent.Homepage();

            var result = new MetaData
            {
                Title = homePage.GetPropertyValue<string>(Constants.Meta.TITLE),
                Description = homePage.GetPropertyValue<string>(Constants.Meta.DESCRIPTION),
                Keywords = homePage.GetPropertyValue<string>(Constants.Meta.KEYWORD),
                Author = homePage.GetPropertyValue<string>(Constants.Meta.AUTHOR),
                FacebookTitle = homePage.GetPropertyValue<string>(Constants.Meta.FACEBOOK_TITLE),
                FacebookImage = homePage.GetPropertyValue<string>(Constants.Meta.FACEBOOK_IMAGE),
                FacebookUrl = homePage.GetPropertyValue<string>(Constants.Meta.FACEBOOK_URL),
                FacebookSiteName = homePage.GetPropertyValue<string>(Constants.Meta.FACEBOOK_SITENAME),
                FacebookDescription = homePage.GetPropertyValue<string>(Constants.Meta.FACEBOOK_DESCRIPTION),

                TwitterTitle = homePage.GetPropertyValue<string>(Constants.Meta.TWITTER_TITLE),
                TwitterImage = homePage.GetPropertyValue<string>(Constants.Meta.TWITTER_IMAGE),
                TwitterUrl = homePage.GetPropertyValue<string>(Constants.Meta.TWITTER_URL),
                TwitterCard = homePage.GetPropertyValue<string>(Constants.Meta.TWITTER_CARD),
            };

            return result;
        }

        /// <summary>
        ///     Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private static List<NavigationListItem> GetNavigationModelFromDatabase(IPublishedContent content)
        {
            var homePage = content.Homepage();
            var nav = new List<NavigationListItem>
            {
                new NavigationListItem(new NavigationLink(homePage.Url, homePage.Name))
            };

            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        ///     Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private static List<NavigationListItem> GetChildNavigationList(IPublishedContent page)
        {
            var childPages = page.Children.Where("Visible")
                .Where(
                    x =>
                        !x.HasValue(Constants.EXCLUDE_FROM_TOP_NAVIGATION) ||
                        x.HasValue(Constants.EXCLUDE_FROM_TOP_NAVIGATION)
                        && !x.GetPropertyValue<bool>(Constants.EXCLUDE_FROM_TOP_NAVIGATION));

            if (!childPages.Any()) return null;
            var listItems = new List<NavigationListItem>();
            foreach (var childPage in childPages)
            {
                var listItem = new NavigationListItem(new NavigationLink(childPage.Url, childPage.Name))
                {
                    Items = GetChildNavigationList(childPage)
                };

                listItems.Add(listItem);
            }

            return listItems;
        }

        #endregion
    }
}