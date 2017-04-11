using PRSiteUmbraco.ViewModels;
using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class SearchModel : BaseModel
    {
        public SearchModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public SearchModel(IPublishedContent content)
            : base(content)
        {
        }

        public SearchViewModel SearchViewModel { get; set; }
    }
}