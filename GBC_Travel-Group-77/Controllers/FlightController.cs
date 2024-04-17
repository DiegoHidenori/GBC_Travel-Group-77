using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    [Route("Flight")]
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly AppDbContext _context;

        // Serilog & session service
        private readonly ILogger<FlightController> _logger;
        private readonly ISessionService _sessionService;

        public FlightController(IFlightRepository flightRepository, AppDbContext context, ILogger<FlightController> logger, ISessionService sessionService)
        {
            _flightRepository = flightRepository;
            _context = context;
            _logger = logger;
            _sessionService = sessionService;
        }

        [Authorize(Roles = "Admin")]
        [Route("Index")]
        public IActionResult Index()
        {
            // Serilog
            _logger.LogInformation("Calling Index action in FlightController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightIndexAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightIndexAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var flights = _flightRepository.AllFlights;
                return View(flights);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [Route("FlightsList")]
        public IActionResult FlightsList()
        {
            // Serilog
            _logger.LogInformation("Calling FlightsList action in FlightController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightFlightsListAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightFlightsListAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("FlightFlightsListPublicVisited") ?? 0;
                    _sessionService.SetSessionData("FlightFlightsListPublicVisited", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var flights = _flightRepository.AllFlights;
                return View(flights);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [Route("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the Details action in FlightController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightDetailsAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightDetailsAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("FlightDetailsPublicVisited") ?? 0;
                    _sessionService.SetSessionData("FlightDetailsPublicVisited", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var flight = _flightRepository.GetFlightById(id);
                if (flight == null)
                {
                    _logger.LogInformation("The flight variable is null");
                    return NotFound();
                }
                return View(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // GET: /Flight/Add
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public IActionResult Add()
        {
            // Serilog
            _logger.LogInformation("Calling the Add (GET) action in FlightController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightAddAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightAddAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // POST: /Flight/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public IActionResult Add(Flight flight)
        {
            // Serilog
            _logger.LogInformation("Calling the Add (POST) action in FlightController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightAddAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightAddAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state is valid");
                    // Add the hotel to the database
                    _context.Flights.Add(flight);
                    _context.SaveChanges();

                    // Redirect to the same page
                    return RedirectToAction(nameof(Add));
                }
                return View(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // GET: /Flight/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the Edit (GET) action in FlightController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightEditAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightEditAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var flight = _context.Flights.Find(id);

                if (flight == null)
                {
                    _logger.LogInformation("Flight variable is null");
                    return NotFound();
                }

                return View(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // POST: /Flight/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id, Flight flight)
        {
            // Serilog
            _logger.LogInformation("Calling the Edit (POST) action in FlightController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightEditAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightEditAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                if (id != flight.id)
                {
                    _logger.LogInformation("The id and the flight id do not match");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state is valid");
                    _context.Flights.Update(flight);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Edit), new { id = flight.id });
                }

                return View(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the Delete (GET) action in FlightController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightDeleteAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightDeleteAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var flight = _flightRepository.GetFlightById(id);

                if (flight == null)
                {
                    _logger.LogInformation("The flight variable is null");
                    return NotFound();
                }

                return View(flight);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // POST: /Flight/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the DeleteConfirmed action in FlightController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("FlightDeleteConfirmedAdminVisited") ?? 0;
                    _sessionService.SetSessionData("FlightDeleteConfirmedAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var flight = _flightRepository.GetFlightById(id);

                if (flight == null)
                {
                    _logger.LogInformation("The flight variable is null");
                    return NotFound();
                }

                _flightRepository.DeleteFlight(flight);
                return RedirectToAction(nameof(FlightsList));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }
    }
}
