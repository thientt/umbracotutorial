using PRSiteUmbraco.Infrastructure;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            NavigationLinkItem = GetNavigationModelFromDatabase(content);
        }

        #region Properties
        public List<NavigationListItem> NavigationLinkItem { get; set; }
        #endregion

        #region Private

        /// <summary>
        ///     Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItem> GetNavigationModelFromDatabase(IPublishedContent content)
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
            List<NavigationListItem> listItems = null;
            var childPages = page.Children.Where("Visible")
                .Where(x => !x.HasValue(Constants.EXCLUDE_FROM_TOP_NAVIGATION) || x.HasValue(Constants.EXCLUDE_FROM_TOP_NAVIGATION)
                && !x.GetPropertyValue<bool>(Constants.EXCLUDE_FROM_TOP_NAVIGATION));

            if (!childPages.Any()) return null;
            listItems = new List<NavigationListItem>();
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