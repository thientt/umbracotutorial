using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class HomeModel : BaseModel
    {
        public HomeModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public HomeModel(IPublishedContent content)
            : base(content)
        {
        }
    }
}