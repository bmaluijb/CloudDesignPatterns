namespace CacheAsidePattern
{
    public static class FakeDataSource
    {
        private static string value = "The value to return";

        public static string GetValueFromDataSource(string key)
        {
            return value;
        }

        public static void UpdateValueToDataSource(string key, string newValue)
        {
            value = newValue;
        }
    }
}
