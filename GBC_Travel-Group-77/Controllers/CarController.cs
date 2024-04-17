using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GBC_Travel_Group_77.Services;

namespace GBC_Travel_Group_77.Controllers
{
    [Route("Car")]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly AppDbContext _context;

        // Serilog && session service
        private readonly ILogger<CarController> _logger;
        private readonly ISessionService _sessionService;

        public CarController(ICarRepository carRepository, AppDbContext context, ILogger<CarController> logger, ISessionService sessionService)
        {
            _carRepository = carRepository;
            _context = context;
            _logger = logger;
            _sessionService = sessionService;
        }

        [Authorize(Roles = "Admin")]
        [Route("Index")]
        public IActionResult Index()
        {
            // Serilog && session service
            _logger.LogInformation("Calling the Index action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarIndexAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarIndexAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var cars = _carRepository.AllCars;
                _logger.LogInformation("Now received the list of cars");
                return View(cars);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [Route("CarsList")]
        public IActionResult CarsList()
        {
            // Serilog
            _logger.LogInformation("Calling the CarsList action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarCarsListAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarCarsListAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("CarCarsListPublicVisited") ?? 0;
                    _sessionService.SetSessionData("CarCarsListPublicVisited", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var cars = _carRepository.AllCars;
                _logger.LogInformation("Now received the list of cars");
                return View(cars);
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
            _logger.LogInformation("Calling the Details action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarDetailsAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarDetailsAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("CarDetailsPublicVisited") ?? 0;
                    _sessionService.SetSessionData("CarDetailsPublicVisited", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var car = _carRepository.GetCarById(id);
                if (car == null)
                {
                    _logger.LogInformation("car variable is null");
                    return NotFound();
                }
                _logger.LogInformation("car variable with given id has been received");
                return View(car);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // GET: /Car/Add
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public IActionResult Add()
        {
            // Serilog
            _logger.LogInformation("Calling the Add (GET) action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarAddAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarAddAdminVisited", adminValue + 1);
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

        // POST: /Car/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public IActionResult Add(Car car)
        {
            // Serilog
            _logger.LogInformation("Calling the Add (POST) action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarAddAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarAddAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state in Add (POST) action is valid");

                    // Add the car to the database
                    _context.Cars.Add(car);
                    _context.SaveChanges();
                    _logger.LogInformation("The context changes has been saved...");

                    // Redirect to the same page
                    return RedirectToAction(nameof(Add));
                }
                return View(car);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // GET: /Car/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the Edit (GET) action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarEditAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarEditAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var car = _context.Cars.Find(id);
                if (car == null)
                {
                    _logger.LogInformation("car variable is null");
                    return NotFound();
                }

                _logger.LogInformation("car variable with given id received");
                return View(car);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // POST: /Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id, Car car)
        {
            // Serilog
            _logger.LogInformation("Calling the Edit (POST) action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarEditAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarEditAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                if (id != car.id)
                {
                    _logger.LogInformation("ID in parameter does not match with the car object");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state in Edit (POST) action is valid");
                    _context.Cars.Update(car);
                    _context.SaveChanges();
                    _logger.LogInformation("The context changes have been saved");
                    return RedirectToAction(nameof(Edit), new { id = car.id });
                }

                return View(car);
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
            _logger.LogInformation("Calling the Delete (GET) action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarDeleteAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarDeleteAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var car = _carRepository.GetCarById(id);
                if (car == null)
                {
                    _logger.LogInformation("car variable is null");
                    return NotFound();
                }
                _logger.LogInformation("car variable is not null");
                return View(car);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        // POST: /Car/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the DeleteConfirmed (POST) action in CarController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("CarDeleteConfirmedAdminVisited") ?? 0;
                    _sessionService.SetSessionData("CarDeleteConfirmedAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var car = _carRepository.GetCarById(id);
                if (car == null)
                {
                    _logger.LogInformation("car variable is null");
                    return NotFound();
                }
                _logger.LogInformation("car variable is not null");
                _carRepository.DeleteCar(car);
                return RedirectToAction(nameof(CarsList));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }
    }
}
