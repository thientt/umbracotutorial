namespace PRSiteUmbraco.ViewModels
{
    public class MetaData
    {
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Author { get; set; }

        //Facebook
        public string OgTitle { get; set; }
        public string OgImage { get; set; }
        public string OgUrl { get; set; }
        public string OgSiteName { get; set; }
        public string OgDescription { get; set; }

        //Twitter
        public string TwitterTitle { get; set; }
        public string TwitterImage { get; set; }
        public string TwitterUrl { get; set; }
        public string TwitterCard { get; set; }
    }
}