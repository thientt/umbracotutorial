namespace PRSiteUmbraco.ViewModels
{
    public class FeaturedItem
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string LinkUrl { get; set; }

        public FeaturedItem(string name, string category, string imageUrl, string linkUrl)
        {
            Name = name;
            Category = category;
            ImageUrl = imageUrl;
            LinkUrl = linkUrl;
        }
    }
}