using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class BlogPostModel : BaseModel
    {
        public BlogPostModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public BlogPostModel(IPublishedContent content)
            : base(content)
        {
        }
    }
}