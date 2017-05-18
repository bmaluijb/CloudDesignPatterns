using StackExchange.Redis;

namespace CacheAsidePattern
{
    class Program
    {

        static void Main(string[] args)
        {
            string key = "examplekey";

            //clear the cache to prep for first use
            ClearCache(key);

            //get value twice to demonstarte pattern
            string value = GetValue(key);
            value = GetValue(key);

            value = "I've just update this value";

            //update and invalidate
            UpdateValue(key, value);

            //get value twice to demonstarte pattern
            string newValue = GetValue(key);
            newValue = GetValue(key);

        }

        public static string GetValue(string key)
        {
            string value = string.Empty;

            //get the value from the cache
            IDatabase cache = CacheService.Connection.GetDatabase();
            RedisValue valueInCache = cache.StringGet(key);

            if (valueInCache.HasValue) //value is in the cache
            {
                value = valueInCache.ToString();
            }
            else //value is not in the cache
            {
                //get value from datasource
                value = FakeDataSource.GetValueFromDataSource(key);

                //set value in cache
                cache.StringSet(key, value);
            }

            return value;
        }

        public static void UpdateValue(string key, string value)
        {
            //invalidate the cache value for the key
            IDatabase cache = CacheService.Connection.GetDatabase();
            cache.KeyDelete(key);

            //update the value in the datasource
            FakeDataSource.UpdateValueToDataSource(key, value);
        }

        public static void ClearCache(string key)
        {
            IDatabase cache = CacheService.Connection.GetDatabase();
            cache.KeyDelete(key);
        }
    }
}
