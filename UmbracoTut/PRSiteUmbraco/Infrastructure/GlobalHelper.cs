using System.Threading;
using System.Web.Configuration;

namespace PRSiteUmbraco.Infrastructure
{
    public class GlobalHelper
    {
        public static string CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name;
            }
        }

        public static string DefaultCulture
        {
            get
            {
                var config = WebConfigurationManager.OpenWebConfiguration("/");
                var section = (GlobalizationSection)config.GetSection("system.web/globalization");
                return section.UICulture;
            }
        }
    }
}