using System.Globalization;
using Umbraco.Core.Models;

namespace PRSiteUmbraco.Models
{
    public class ContactModel : BaseModel
    {
        public ContactModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture)
        {
        }

        public ContactModel(IPublishedContent content) : base(content)
        {
        }
    }
}