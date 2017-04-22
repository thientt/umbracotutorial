namespace PRSiteUmbraco.Infrastructure
{
    public class Constants
    {
        public static int CACHE_TIME = 5 * 60; //5 miliseconds

        public static string EXCLUDE_FROM_TOP_NAVIGATION = "excludeFromTopNavigation";

        public static string FEATURED_ITEMS = "featuredItems";
        public static string IMAGE_ALIAS = "image";
        public static string INTRODUCTION_ALIAS = "introduction";

        public class Archetype
        {
            public static string ALIAS_IMAGE = "image";
            public static string ALIAS_NAME = "name";
            public static string ALIAS_CATEGORY = "category";
            public static string ALIAS_PAGE = "page";
        }

        public class Page
        {
            public const string HOME_PAGE_DOC_TYPE_ALIAS = "home";
            public const string BLOG_PAGE_DOC_TYPE_ALIAS = "blog";
        }
    }
}