using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class CookieModel:BaseModel
    {
        public CookieModel(IPublishedContent content, CultureInfo culture)
            :base(content, culture)
        {
        }

        public CookieModel(IPublishedContent content)
            : base(content)
        {
        }
    }
}