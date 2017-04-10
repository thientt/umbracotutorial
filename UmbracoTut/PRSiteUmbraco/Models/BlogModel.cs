using System;
using System.Collections.Generic;
using System.Globalization;
using PRSiteUmbraco.Infrastructure;
using PRSiteUmbraco.ViewModels;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class BlogModel : BaseModel
    {
        private readonly Func<IEnumerable<BlogPreview>> _getBlogItems = () =>
        {
            var blogPage = PublishedContent.Blogpage();

            var blogItems = new List<BlogPreview>();
            var childPages = blogPage.Children.Where("Visible");

            foreach (var page in childPages)
            {
                var imageId = page.GetPropertyValue<int>(Constants.Article.IMAGE);
                var mediaItem = UmbracoHelper.Media(imageId);
                string imageUrl = mediaItem.Url;

                blogItems.Add(new BlogPreview(
                    page.Name, page.GetPropertyValue<string>(Constants.Article.INTRODUCTION),
                    imageUrl, page.Url));
            }
            return blogItems;
        };

        public BlogModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public BlogModel(IPublishedContent content) : base(content)
        {
        }

        public Lazy<IEnumerable<BlogPreview>> BlogItems
        {
            get
            {
                return new Lazy<IEnumerable<BlogPreview>>(() =>
                    Helper.GetObjectFromCache(
                        string.Format("{0}_blogitems", CurrentCulture.TwoLetterISOLanguageName), Constants.CACHE_TIME, _getBlogItems)
                    );
            }
        }
    }
}