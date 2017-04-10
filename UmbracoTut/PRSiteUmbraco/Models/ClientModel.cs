using System.Collections.Generic;

namespace PRSiteUmbraco.Models
{
    public class ClientModel
    {
        public string TerminalTitle { get; set; }

        public string TerminalIntroduction { get; set; }

        public IEnumerable<TestimonyModel> Testimonies { get; set; }
    }
}