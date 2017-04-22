using System;
using System.Collections.Generic;
using System.Linq;
using Examine;
using Examine.SearchCriteria;
using PRSiteUmbraco.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Infrastructure
{
    /// <summary>
    ///     A helper class giving you everything you need for searching with Examine.
    /// </summary>
    public class SearchHelper
    {
        /// <summary>
        ///     Default constructor for SearchHelper
        /// </summary>
        /// <param name="umbracoHelper">An umbraco helper to use in your class</param>
        public SearchHelper(UmbracoHelper umbracoHelper)
        {
            UmbracoHelper = umbracoHelper;
        }

        private string _docTypeAliasFieldName => "nodeTypeAlias";
        private UmbracoHelper UmbracoHelper { get; }

        /// <summary>
        ///     Gets the search results model from the search term///
        /// </summary>
        /// <param name="searchModel">The search model with search term and other settings in it</param>
        /// <param name="allKeys">The form keys that were submitted</param>
        /// <returns>A SearchResultsModel object loaded with the results</returns>
        public SearchResultsModel GetSearchResults(SearchViewModel searchModel, string[] allKeys)
        {
            var resultsModel = new SearchResultsModel
            {
                SearchTerm = searchModel.SearchTerm,
                PageNumber = GetPageNumber(allKeys)
            };

            var allResults = SearchUsingExamine(searchModel.DocTypeAliases.Split(','), searchModel.SearchGroups);
            resultsModel.TotalItemCount = allResults.TotalItemCount;
            resultsModel.Results = GetResultsForThisPage(allResults, resultsModel.PageNumber, searchModel.PageSize);

            resultsModel.PageCount =
                Convert.ToInt32(Math.Ceiling(resultsModel.TotalItemCount/(decimal) searchModel.PageSize));
            resultsModel.PagingBounds = GetPagingBounds(resultsModel.PageCount, resultsModel.PageNumber,
                searchModel.PagingGroupSize);
            return resultsModel;
        }

        /// <summary>
        ///     Takes the examine search results and return the content for each page
        /// </summary>
        /// <param name="allResults">The examine search results</param>
        /// <param name="pageNumber">The page number of results to return</param>
        /// <param name="pageSize">The number of items per page</param>
        /// <returns>A collection of content pages for the page of results</returns>
        private IEnumerable<IPublishedContent> GetResultsForThisPage(ISearchResults allResults, int pageNumber,
            int pageSize)
        {
            return
                allResults.Skip((pageNumber - 1)*pageSize).Take(pageSize).Select(x => UmbracoHelper.TypedContent(x.Id));
        }

        /// <summary>
        ///     Performs a lucene search using Examine.
        /// </summary>
        /// <param name="documentTypes">Array of document type aliases to search for.</param>
        /// <param name="searchGroups">
        ///     A list of search groupings, if you have more than one group it will apply an and to the
        ///     search criteria
        /// </param>
        /// <returns>Examine search results</returns>
        public ISearchResults SearchUsingExamine(string[] documentTypes, List<SearchGroup> searchGroups)
        {
            var searchCriteria = ExamineManager.Instance.CreateSearchCriteria(BooleanOperation.And);

            //only shows results for visible documents.
            var queryNodes = searchCriteria.GroupedNot(new[] {"umbracoNaviHide"}, "1");

            if (documentTypes != null && documentTypes.Length > 0)
            {
                //only get results for documents of a certain type
                queryNodes = queryNodes.And().GroupedOr(new[] {_docTypeAliasFieldName}, documentTypes);
            }

            if (searchGroups == null || !searchGroups.Any())
                return ExamineManager.Instance.Search(queryNodes.Compile());
            //in each search group it looks for a match where the specified fields contain any of the specified search terms
            //usually would only have 1 search group, unless you want to filter out further, i.e. using categories as well as search terms
            queryNodes = searchGroups.Aggregate(queryNodes,
                (current, searchGroup) => current.And().GroupedOr(searchGroup.FieldsToSearchIn, searchGroup.SearchTerms));

            //return the results of the search
            return ExamineManager.Instance.Search(queryNodes.Compile());
        }

        /// <summary>
        ///     Gets the page number from the form keys
        /// </summary>
        /// <param name="formKeys">All of the keys on the form</param>
        /// <returns>The page number</returns>
        public int GetPageNumber(string[] formKeys)
        {
            var pageNumber = 1;
            const string namePrefix = "page";
            const char nameSeparator = '-';
            if (formKeys == null) return pageNumber;
            var pagingButtonName =
                formKeys.FirstOrDefault(
                    x => x.Length > namePrefix.Length && x.Substring(0, namePrefix.Length).ToLower() == namePrefix);
            if (string.IsNullOrEmpty(pagingButtonName)) return pageNumber;
            var pagingButtonNameParts = pagingButtonName.Split(nameSeparator);
            if (pagingButtonNameParts.Length <= 1) return pageNumber;
            if (!int.TryParse(pagingButtonNameParts[1], out pageNumber))
            {
                //pageNumber already set in tryparse
            }
            return pageNumber;
        }

        /// <summary>
        ///     Works out which pages the paging should start and end on
        /// </summary>
        /// <param name="pageCount">The number of pages</param>
        /// <param name="pageNumber">The current page number</param>
        /// <param name="groupSize">The number of items per page</param>
        /// <returns>A PagingBoundsModel containing the paging bounds settings</returns>
        public PagingBoundsModel GetPagingBounds(int pageCount, int pageNumber, int groupSize)
        {
            var middlePageNumber = (int) (Math.Ceiling((decimal) groupSize/2));
            var pagesBeforeMiddle = groupSize - middlePageNumber;
            var pagesAfterMiddle = groupSize - (pagesBeforeMiddle + 1);
            var startPage = 1;
            if (pageNumber >= middlePageNumber)
            {
                startPage = pageNumber - pagesBeforeMiddle;
            }
            else
            {
                pagesAfterMiddle = groupSize - pageNumber;
            }
            var endPage = pageCount;
            if (pageCount >= (pageNumber + pagesAfterMiddle))
            {
                endPage = (pageNumber + pagesAfterMiddle);
            }
            var showFirstButton = startPage > 1;
            var showLastButton = endPage < pageCount;
            return new PagingBoundsModel(startPage, endPage, showFirstButton, showLastButton);
        }
    }
}