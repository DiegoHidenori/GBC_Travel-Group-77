using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class FlightController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IFlightRepository _flightRepository;
        public FlightController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public IActionResult FlightsList()
        {
            var flights = _flightRepository.AllFlights;
            return View(flights);
        }

        public IActionResult Details(int id)
        {
            var flight = _flightRepository.GetFlightById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }
    }
}
