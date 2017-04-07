using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class AboutModel : BaseModel
    {
        public AboutModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public AboutModel(IPublishedContent content) : base(content)
        {
        }
    }
}