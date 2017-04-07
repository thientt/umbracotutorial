using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class ServicesModel : BaseModel
    {
        public ServicesModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public ServicesModel(IPublishedContent content) : base(content)
        {
        }
    }
}