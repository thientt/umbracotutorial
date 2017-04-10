﻿namespace PRSiteUmbraco.Infrastructure
{
    public class Constants
    {
        public const int CACHE_TIME = 5; //5 miliseconds

        public const string EXCLUDE_FROM_TOP_NAVIGATION = "excludeFromTopNavigation";

        public const string FEATURED_ITEMS = "featuredItems";

        public class Article
        {
            public const string INTRODUCTION = "articleIntro";
            public const string IMAGE = "articleimage";
        }

        public class Page
        {
            public const string ALIAS_HOME = "home";
            public const string ALIAS_BLOG = "blog";
        }

        public class Archetype
        {
            public const string ALIAS_IMAGE = "image";
            public const string ALIAS_NAME = "name";
            public const string ALIAS_CATEGORY = "category";
            public const string ALIAS_PAGE = "page";
        }

        public class Client
        {
            public const string CLIENT_INTRODUCTION = "terminalIntroduction";
            public const string CLIENT_TITLE = "terminalTitle";

            public const string TESTIMONIES = "testimonies";
            public const string TESTIMONIES_AUTHOR = "author";
            public const string TESTIMONIES_INTRODUCTION = "introduction";
            public const string TESTIMONIES_ICONLINK = "iconLink";
        }
    }
}