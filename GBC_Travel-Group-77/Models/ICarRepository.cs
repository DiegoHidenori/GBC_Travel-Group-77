namespace GBC_Travel_Group_77.Models
{
    public interface ICarRepository
    {
        IEnumerable<Car> AllCars { get; }
        IEnumerable<Car> CarsHotDeals { get; }
        Car? GetCarById(int carId);
    }
}
