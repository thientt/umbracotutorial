using System.Globalization;
using Umbraco.Core.Models;

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
    }
}