using System;
using System.Runtime.Caching;

namespace PRSiteUmbraco.Infrastructure
{
    public static class Helper
    {
        /// <summary>
        /// A generic function for getting and setting objects to the memory cache.
        /// </summary>
        /// <typeparam name="T">The type of the object to be returned.</typeparam>
        /// <param name="cacheItemName">The name to be used when storing this object in the cache.</param>
        /// <param name="cacheTimeInMinutes">How long to cache this object for.</param>
        /// <param name="objectSettingFunction">A parameterless function to call if the object isn't in the cache and you need to set it.</param>
        /// <returns>An object of the type you asked for</returns>
        public static T GetObjectFromCache<T>(string cacheItemName, int cacheTimeInMinutes, Func<T> objectSettingFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            var cacheObject = (T)cache[cacheItemName];
            if (cacheObject == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes);
                cacheObject = objectSettingFunction();
                cache.Set(cacheItemName, cacheObject, policy);
            }

            return cacheObject;
        }

        public static string RenameHomePage(this string homePage)
        {
            if (string.IsNullOrEmpty(homePage))
                throw new ArgumentException("HomePage value not null or empty");

            if (homePage.Equals("VietNamese", StringComparison.InvariantCultureIgnoreCase))
                return "Trang chủ";

            if (homePage.Equals("English", StringComparison.InvariantCultureIgnoreCase))
                return "Home";

            return homePage;
        }
    }
}