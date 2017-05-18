using System.Linq;

namespace CQRSPattern
{
    public static class ConsitencyWorker
    {
        public static void Create(CarDetails car)
        {
            QueryDataStore.Cars.Add(
                new Car
                {
                    Id = car.Id,
                    BrandName = car.BrandName,
                    Price = car.Price,
                    Year = car.Year
                }
            );
        }

        public static void UpdateYear(int id, int year)
        {
            Car car = QueryDataStore.Cars.Single(c => c.Id == id);
            if (car != null)
            {
                car.Year = year;
            }
        }

        public static void Delete(int id)
        {
            QueryDataStore.Cars
                .Remove(QueryDataStore.Cars.Single(c => c.Id == id));
        }
    }
}
