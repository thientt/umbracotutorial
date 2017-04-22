using System.Collections.Generic;
using System.Web.Mvc;
using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.Models;
using PRSiteUmbraco.ViewModels;
using Umbraco.Web;

namespace PRSiteUmbraco.Controllers
{
    public class SearchController : BaseController
    {
        #region Private Variables and Methods

        private readonly UmbracoHelper _umbracoHelper = new UmbracoHelper(UmbracoContext.Current);

        private SearchHelper SearchHelper => new SearchHelper(_umbracoHelper);

        private static string PartialViewPath(string name)
        {
            return string.Format("~/Views/Partials/Search/{0}.cshtml", name);
        }

        private static List<SearchGroup> GetSearchGroups(SearchViewModel model)
        {
            List<SearchGroup> searchGroups = null;
            if (!string.IsNullOrEmpty(model.FieldPropertyAliases))
            {
                searchGroups = new List<SearchGroup>
                {
                    new SearchGroup(model.FieldPropertyAliases.Split(','), new[] {model.SearchTerm})
                };
            }
            return searchGroups;
        }

        #endregion

        #region Controller Actions

        [HttpGet]
        public ActionResult Search()
        {
            var model = new SearchModel(CurrentPage);
            var searchPage = CurrentPage.Searchpage();
            model.SearchViewModel = new SearchViewModel
            {
                SearchTerm = string.Empty,
                PageSize = searchPage.GetPropertyValue<int>(Constants.Search.PAGE_SIZE),
                PagingGroupSize = searchPage.GetPropertyValue<int>(Constants.Search.PAGING_GROUP_SIZE),
                DocTypeAliases = searchPage.GetPropertyValue<string>(Constants.Search.DOCTYPE_ALIASES),
                FieldPropertyAliases = searchPage.GetPropertyValue<string>(Constants.Search.FIELD_PROPERTYALIASED)
            };
            model.SearchViewModel.SearchGroups = GetSearchGroups(model.SearchViewModel);
            model.SearchViewModel.SearchResults = SearchHelper.GetSearchResults(model.SearchViewModel,
                Request.Form.AllKeys);

            return CurrentTemplate(model);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel model)
        {
            if (!ModelState.IsValid) return null;
            if (string.IsNullOrEmpty(model.SearchTerm)) return RenderSearchResults(model.SearchResults);
            model.SearchTerm = model.SearchTerm;
            model.SearchGroups = GetSearchGroups(model);
            model.SearchResults = SearchHelper.GetSearchResults(model, Request.Form.AllKeys);
            return RenderSearchResults(model.SearchResults);
        }

        public ActionResult RenderSearchResults(SearchResultsModel model)
        {
            return PartialView(PartialViewPath("_SearchResults"), model);
        }

        #endregion
    }
}