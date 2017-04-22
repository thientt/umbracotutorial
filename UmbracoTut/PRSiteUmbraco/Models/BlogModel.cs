using System;
using System.Globalization;
using Umbraco.Core.Models;
using PRSiteUmbraco.ViewModels;
using System.Collections.Generic;
using PRSiteUmbraco.Infrastructure;
using System.Linq;
using Umbraco.Core;
using Umbraco.Web;

namespace PRSiteUmbraco.Models
{
    public class BlogModel : BaseModel
    {
        public BlogModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public BlogModel(IPublishedContent content) : base(content)
        {
        }

        Func<IEnumerable<BlogPreviewViewModel>> GetBlogPreviewItems = () =>
        {
            List<BlogPreviewViewModel> items = new List<BlogPreviewViewModel>();
            IPublishedContent blogPage = PublishedContent.BlogPage();
            foreach (IPublishedContent blog in blogPage.Children)
            {
                int imageId = blog.GetPropertyValue<int>(Infrastructure.Constants.IMAGE_ALIAS);
                var mediaItem = UmbracoHelper.Media(imageId);
                string imageUrl = mediaItem.Url;
                string linkUrl = blog.Url;

                items.Add(new BlogPreviewViewModel(blog.Name,
                    blog.GetPropertyValue<string>(Infrastructure.Constants.INTRODUCTION_ALIAS),
                    imageUrl, linkUrl
                    ));
            }

            return items;
        };

        public Lazy<IEnumerable<BlogPreviewViewModel>> BlogPreviewItems
        {
            get
            {
                return new Lazy<IEnumerable<BlogPreviewViewModel>>(() => GetBlogPreviewItems());
            }
        }
    }
}