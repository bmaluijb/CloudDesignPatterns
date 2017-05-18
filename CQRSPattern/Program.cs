using System;
using System.Collections.Generic;

namespace CQRSPattern
{
    class Program
    {
        private static CarCommandService _commandService 
            = new CarCommandService();
        private static CarQueryService _queryService 
            = new CarQueryService();

        static void Main(string[] args)
        {
            Console.WriteLine("Press Key to create a car...");
            Console.ReadLine();

            _commandService.CreateCar(new CarDetails
            {
                Id = 6546,
                BrandName = "Toyota",
                Emissions = 0.9,
                Insured = true,
                LicenseNumber = "ZZ-KK89-LLP",
                Price = 35000,
                Year = 2012
            });

            _commandService.CreateCar(new CarDetails
            {
                Id = 123587,
                BrandName = "Ford",
                Emissions = 1.5,
                Insured = true,
                LicenseNumber = "OO-MYFORD-07",
                Price = 12500,
                Year = 2007
            });

            Console.WriteLine("Press Key to read the first car info...");
            Console.ReadLine();

            Car car = _queryService.GetCar(6546);

            Console.WriteLine("Brand: " + car.BrandName);
            Console.WriteLine("Year: " + car.Year);
            Console.WriteLine("Price: " + car.Price);

            Console.WriteLine("Press Key to update car year...");
            Console.ReadLine();

            _commandService.ChangeCarYear(car.Id, 2007);

            Console.WriteLine("Press Key to get cars from 2007...");
            Console.ReadLine();

            List<Car> cars = _queryService.GetCarsFromYear(2007);
            foreach (var c in cars)
            {
                Console.WriteLine("2007 car brand: " + c.BrandName);
            }

            Console.ReadLine();
        }
    }
}
