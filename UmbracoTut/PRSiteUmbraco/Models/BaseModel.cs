using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using PRSiteUmbraco.Infrastructure;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class BaseModel : RenderModel
    {
        public BaseModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public BaseModel(IPublishedContent content)
            : base(content)
        {
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
                .Where(x => !x.HasValue(Contants.EXCLUDE_FROM_TOP_NAVIGATION) || x.HasValue(Contants.EXCLUDE_FROM_TOP_NAVIGATION)
                && !x.GetPropertyValue<bool>(Contants.EXCLUDE_FROM_TOP_NAVIGATION));

            if (childPages == null || !childPages.Any()) return null;
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