using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class SearchItemController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IFlightRepository _flightRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ICarRepository _carRepository;
        public SearchItemController(IFlightRepository flightRepository, IHotelRepository hotelRepository, ICarRepository carRepository)
        {
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;
            _carRepository = carRepository;

        }

        public ViewResult Index(string keyWord)
        {
            int yearFilter;
            bool isYear = int.TryParse(keyWord.ToLower(), out yearFilter);

            var filteredCars = _carRepository.AllCars.Where(car =>
                    car.category.ToLower() == keyWord.ToLower() ||
                    car.model.ToLower() == keyWord.ToLower() ||
                    car.make.ToLower() == keyWord.ToLower() ||
                    (isYear && car.yearManufactured == yearFilter) ||
                    car.color.ToLower() == keyWord.ToLower() ||
                    car.licensePlate.ToLower() == keyWord.ToLower() ||
                    car.type.ToLower() == keyWord.ToLower() ||
                    (isYear && car.seatCapacity == yearFilter)
                ).ToList();

            var filteredHotels = _hotelRepository.AllHotels.Where(hotel =>
                    hotel.category.ToLower().Contains(keyWord.ToLower()) ||
                    hotel.name.ToLower().Contains(keyWord.ToLower()) ||
                    hotel.city.ToLower().Contains(keyWord.ToLower()) ||
                    hotel.country.ToLower().Contains(keyWord.ToLower()) ||
                    hotel.roomTypes.ToLower().Contains(keyWord.ToLower())
                ).ToList();

            var filteredFlights = _flightRepository.AllFlights.Where(flight =>
                    flight.category.ToLower() == keyWord.ToLower() ||
                    flight.company.ToLower() == keyWord.ToLower() ||
                    flight.departureAirport.ToLower().Contains(keyWord.ToLower()) ||
                    flight.departureGate.ToLower().Contains(keyWord.ToLower()) ||
                    flight.arrivalAirport.ToLower().Contains(keyWord.ToLower()) ||
                    flight.arrivalGate.ToLower().Contains(keyWord.ToLower()) ||
                    flight.flightStatus.ToLower().Contains(keyWord.ToLower())
                ).ToList();

            var homeViewModel = new HomeViewModel(
                filteredFlights.AsEnumerable(),
                filteredHotels.AsEnumerable(),
                filteredCars.AsEnumerable()
            );
            return View(homeViewModel);
        }
    }
}
