namespace PRSiteUmbraco.ViewModels
{
    public class BlogPreview
    {
        public string Name { get; set; }

        public string Introduction { get; set; }

        public string ImageUrl { get; set; }

        public string LinkUrl { get; set; }

        public BlogPreview(string name, string introduction, string imageUrl, string linkUrl)
        {
            this.Name = name;
            this.Introduction = introduction;
            this.ImageUrl = imageUrl;
            this.LinkUrl = linkUrl;
        }
    }
}