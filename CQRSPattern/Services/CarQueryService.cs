using System.Collections.Generic;
using System.Linq;

namespace CQRSPattern
{
    public class CarQueryService
    {
        public Car GetCar(int id)
        {
            return QueryDataStore.Cars.Single(c => c.Id == id);
        }

        public List<Car> GetCarsFromYear(int year)
        {
            return QueryDataStore.Cars.Where(c => c.Year == year).ToList();
        }
    }
}
