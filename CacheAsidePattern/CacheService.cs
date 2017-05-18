using StackExchange.Redis;
using System;
using System.Configuration;

namespace CacheAsidePattern
{
    public static class CacheService
    {

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var connectionString = 
                ConfigurationManager.ConnectionStrings["AzureRedisConnectionString"].ConnectionString;

            return ConnectionMultiplexer.Connect(connectionString);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
