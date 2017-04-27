namespace PRSiteUmbraco.ViewModels
{
    public class MetaData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Author { get; set; }

        //Facebook
        public string FacebookTitle { get; set; }
        public string FacebookImage { get; set; }
        public string FacebookUrl { get; set; }
        public string FacebookSiteName { get; set; }
        public string FacebookDescription { get; set; }

        //Twitter
        public string TwitterTitle { get; set; }
        public string TwitterImage { get; set; }
        public string TwitterUrl { get; set; }
        public string TwitterCard { get; set; }
    }
}