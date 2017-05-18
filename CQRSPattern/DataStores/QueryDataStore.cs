using System.Collections.Generic;

namespace CQRSPattern
{
    public static class QueryDataStore
    {
        static QueryDataStore()
        {
            Cars = new List<Car>();
        }

        public static List<Car> Cars { get; set; }
    }
}
