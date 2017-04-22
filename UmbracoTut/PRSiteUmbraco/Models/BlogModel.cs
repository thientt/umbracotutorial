using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PRSiteUmbraco.Entities;
using PRSiteUmbraco.Infrastructure;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class BlogModel : BaseModel
    {
        private readonly Func<IEnumerable<BlogPreview>> _getBlogItems = () =>
        {
            var blogPage = PublishedContent.Blogpage();

            var childPages = blogPage.Children.Where(x => x.IsVisible());

            return (from page in childPages
                let imageId = page.GetPropertyValue<int>(Constants.Article.IMAGE)
                let mediaItem = UmbracoHelper.Media(imageId)
                let imageUrl = mediaItem.Url
                select new BlogPreview(page.Name, page.GetPropertyValue<string>(Constants.Article.INTRODUCTION),
                    (string) imageUrl, page.Url)).ToList();
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
                        string.Format("{0}_blogitems", CurrentCulture.TwoLetterISOLanguageName), Constants.CACHE_TIME,
                        _getBlogItems)
                    );
            }
        }
    }
}