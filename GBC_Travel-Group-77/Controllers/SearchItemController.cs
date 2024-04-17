using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using GBC_Travel_Group_77.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class SearchItemController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ICarRepository _carRepository;
        private readonly ILogger<SearchItemController> _logger;
        private readonly ISessionService _sessionService;

        public SearchItemController(IFlightRepository flightRepository, IHotelRepository hotelRepository, ICarRepository carRepository, ILogger<SearchItemController> logger, ISessionService sessionService)
        {
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;
            _carRepository = carRepository;
            _logger = logger;
            _sessionService = sessionService;
        }

        public ViewResult Index(string keyWord)
        {
            try
            {
                // Serilog
                _logger.LogInformation("Calling SearchItem Index action");

                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("SearchItemIndexAdmin") ?? 0;
                    _sessionService.SetSessionData("SearchItemIndexAdmin", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("SearchItemIndexPublic") ?? 0;
                    _sessionService.SetSessionData("SearchItemIndexPublic", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                if (string.IsNullOrEmpty(keyWord))
                {
                    _logger.LogInformation("The keyword is null or empty...");
                    var allCars = _carRepository.AllCars.ToList();
                    var allHotels = _hotelRepository.AllHotels.ToList();
                    var allFlights = _flightRepository.AllFlights.ToList();

                    var homeViewModel = new HomeViewModel(
                        allFlights.AsEnumerable(),
                        allHotels.AsEnumerable(),
                        allCars.AsEnumerable()
                    );
                    return View(homeViewModel);
                }
                else
                {
                    _logger.LogInformation("The keyword is not null or empty");
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }
    }
}
