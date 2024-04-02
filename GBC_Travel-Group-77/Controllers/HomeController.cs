using GBC_Travel_Group_77.Models;
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

        public HomeController(IFlightRepository flightRepository, ICarRepository carRepository, IHotelRepository hotelRepository)
        {
            _flightRepository = flightRepository;
            _carRepository = carRepository;
            _hotelRepository = hotelRepository;
        }

        public IActionResult Index()
        {
            var flightHotDeals = _flightRepository.FlightsHotDeals;
            var carHotDeals = _carRepository.CarsHotDeals;
            var hotelHotDeals = _hotelRepository.HotelsHotDeals;
            var homeViewModel = new HomeViewModel(flightHotDeals, hotelHotDeals, carHotDeals);

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
