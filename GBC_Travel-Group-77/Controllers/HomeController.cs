using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using GBC_Travel_Group_77.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GBC_Travel_Group_77.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ICarRepository _carRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionService _sessionService;

        public HomeController(IFlightRepository flightRepository, ICarRepository carRepository, IHotelRepository hotelRepository, ILogger<HomeController> logger, ISessionService sessionService)
        {
            _flightRepository = flightRepository;
            _carRepository = carRepository;
            _hotelRepository = hotelRepository;
            _logger = logger;
            _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            // Serilog
            _logger.LogInformation("Calling the Index action in HomeController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HomeIndexAdmin") ?? 0;
                    _sessionService.SetSessionData("HomeIndexAdmin", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("HomeIndexPublic") ?? 0;
                    _sessionService.SetSessionData("HomeIndexPublic", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var flightHotDeals = _flightRepository.FlightsHotDeals;
                var carHotDeals = _carRepository.CarsHotDeals;
                var hotelHotDeals = _hotelRepository.HotelsHotDeals;
                var homeViewModel = new HomeViewModel(flightHotDeals, hotelHotDeals, carHotDeals);

                return View(homeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        public IActionResult NotFound(int statusCode)
        {
            _logger.LogInformation("Calling the NotFound action in HomeController");
            if (statusCode == 404)
            {
                _logger.LogInformation("The status code is 404");
                return View("NotFound");
            }
            return View("Error");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogInformation("Calling the Error action in HomeController");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
