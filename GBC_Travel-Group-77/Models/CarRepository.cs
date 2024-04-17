using GBC_Travel_Group_77.Data;
using System.Linq;
using System.Collections.Generic;

namespace GBC_Travel_Group_77.Models
{
    public class CarRepository : ICarRepository
    {
        public readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Car> AllCars
        {
            get
            {
                try
                {
                    return _appDbContext.Cars;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retreiving all the cars: ", ex);
                }
            }
        }

        public IEnumerable<Car> CarsHotDeals
        {
            get
            {
                try
                {
                    return _appDbContext.Cars.Where(p => p.isHotDeal);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving the hot deals: ", ex);
                }
            }
        }

        public void AddCar(Car car)
        {
            try
            {
                _appDbContext.Cars.Add(car);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding a car: ", ex);
            }
        }

        public void UpdateCar(Car car)
        {
            try
            {
                _appDbContext.Cars.Update(car);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating a car: ", ex);
            }
        }

        public void DeleteCar(Car car)
        {
            try
            {
                _appDbContext.Cars.Remove(car);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting a car: ", ex);
            }
        }

        public Car? GetCarById(int id)
        {
            try
            {
                return _appDbContext.Cars.FirstOrDefault(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting a car with the id: ", ex);
            }
        }
    }
}
