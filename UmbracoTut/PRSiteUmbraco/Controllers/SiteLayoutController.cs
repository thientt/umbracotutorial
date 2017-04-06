using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Linq;
using System.Data.Sql;

namespace PRSiteUmbraco.Controllers
{
    public class SiteLayoutController : BaseController
    {
        private const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/SiteLayout/";

        public ActionResult RenderHeader()
        {
            var nav = Helper.GetObjectFromCache<List<NavigationListItem>>("mainNav", 5, GetNavigationModelFromDatabase);
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
        /// Finds the home page and gets the navigation structure based on it and it's children
        /// </summary>
        /// <returns>A List of NavigationListItems, representing the structure of the site.</returns>
        private List<NavigationListItem> GetNavigationModelFromDatabase()
        {
            const string HOME_PAGE_DOC_TYPE_ALIAS = "home";
            IPublishedContent homePage = CurrentPage.AncestorOrSelf(1).DescendantsOrSelf().Where(x => x.DocumentTypeAlias == HOME_PAGE_DOC_TYPE_ALIAS).FirstOrDefault();
            List<NavigationListItem> nav = new List<NavigationListItem>();
            nav.Add(new NavigationListItem(new NavigationLink(homePage.Url, homePage.Name)));
            nav.AddRange(GetChildNavigationList(homePage));
            return nav;
        }

        /// <summary>
        /// Loops through the child pages of a given page and their children to get the structure of the site.
        /// </summary>
        /// <param name="page">The parent page which you want the child structure for</param>
        /// <returns>A List of NavigationListItems, representing the structure of the pages below a page.</returns>
        private List<NavigationListItem> GetChildNavigationList(IPublishedContent page)
        {
            List<NavigationListItem> listItems = null;
            var childPages = page.Children.Where("Visible");
            if (childPages != null && childPages.Any() && childPages.Count() > 0)
            {
                listItems = new List<NavigationListItem>();
                foreach (var childPage in childPages)
                {
                    NavigationListItem listItem = new NavigationListItem(new NavigationLink(childPage.Url, childPage.Name));
                    listItem.Items = GetChildNavigationList(childPage);
                    listItems.Add(listItem);
                }
            }
            return listItems;
        }
    }
}