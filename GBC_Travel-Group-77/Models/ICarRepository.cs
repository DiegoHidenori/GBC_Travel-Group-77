namespace GBC_Travel_Group_77.Models
{
    public interface ICarRepository
    {
        IEnumerable<Car> AllCars { get; }
        IEnumerable<Car> CarsHotDeals { get; }
        Car? GetCarById(int carId);
        void AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
    }
}
