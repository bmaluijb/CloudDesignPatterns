using System.Linq;

namespace CQRSPattern
{
    public class CarCommandService
    {
        public void CreateCar(CarDetails car)
        {
            CommandDataStore.CarDetails.Add(car);

            //update the read datastore
            ConsitencyWorker.Create(car);
        }

        public void ChangeCarYear(int id, int year)
        {
            CarDetails car = 
                CommandDataStore.CarDetails.Single(c => c.Id == id);
            if(car != null)
            {
                car.Year = year;
            }

            //update the read datastore
            ConsitencyWorker.UpdateYear(id, year);
        }

        public void DeleteCar(int id)
        {
            CommandDataStore.CarDetails
                .Remove(CommandDataStore.CarDetails.Single(c => c.Id == id));

            //update the read datastore
            ConsitencyWorker.Delete(id);
        }
    }
}
