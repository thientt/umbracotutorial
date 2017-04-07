using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class PortfolioModel : BaseModel
    {
        public PortfolioModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public PortfolioModel(IPublishedContent content) : base(content)
        {
        }
    }
}