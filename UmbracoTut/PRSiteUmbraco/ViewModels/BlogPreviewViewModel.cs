﻿namespace PRSiteUmbraco.ViewModels
{
    public class BlogPreviewViewModel
    {
        public BlogPreviewViewModel(string name, string introduction, string imageUrl, string linkUrl)
        {
            Name = name;
            Introduction = introduction;
            ImageUrl = imageUrl;
            LinkUrl = linkUrl;
        }

        public string Name { get; set; }
        public string Introduction { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
    }
}