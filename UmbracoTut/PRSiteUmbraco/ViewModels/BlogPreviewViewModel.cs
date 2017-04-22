namespace PRSiteUmbraco.ViewModels
{
    public class BlogPreviewViewModel
    {
        public string Name { get; set; }

        public string Introduction { get; set; }

        public string ImageUrl { get; set; }

        public string LinkUrl { get; set; }

        public BlogPreviewViewModel(string name, string introduction, string imageUrl, string linkUrl)
        {
            this.Name = name;
            this.Introduction = introduction;
            this.ImageUrl = imageUrl;
            this.LinkUrl = linkUrl;
        }
    }
}