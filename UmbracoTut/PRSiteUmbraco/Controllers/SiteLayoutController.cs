using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.Models;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Controllers
{
    public class SiteLayoutController : BaseController
    {
        // ReSharper disable once InconsistentNaming
        private const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/SiteLayout/";

        public ActionResult RenderHeader()
        {
            var nav = Helper.GetObjectFromCache(string.Format("{0}_{1}", Culture, "mainNav"), Contants.CACHE_TIME, GetNavigationModelFromDatabase);
            return PartialView(PARTIAL_VIEW_FOLDER + "_Header.cshtml", nav);
        }

        public ActionResult RenderFooter()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Footer.cshtml");
        }

        public ActionResult RenderIntro()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Intro.cshtml");
        }

        public ActionResult RenderTitleControl()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_TitleControl.cshtml");
        }

        /// <summary>
        ///     Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItem> GetNavigationModelFromDatabase()
        {
            const string HOME_PAGE_DOC_TYPE_ALIAS = "home";
            var homePage =
                CurrentPage.AncestorOrSelf(1)
                    .DescendantsOrSelf().FirstOrDefault(x => x.DocumentTypeAlias == HOME_PAGE_DOC_TYPE_ALIAS);
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
            var childPages = page.Children.Where("Visible");
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
    }
}