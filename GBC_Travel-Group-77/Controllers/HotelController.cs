using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    [Route("Hotel")]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly AppDbContext _context;

        //Serilog
        private readonly ILogger<HotelController> _logger;
        private readonly ISessionService _sessionService;

        public HotelController(IHotelRepository hotelRepository, AppDbContext context, ILogger<HotelController> logger, ISessionService sessionService)
        {
            _hotelRepository = hotelRepository;
            _context = context;
            _logger = logger;
            _sessionService = sessionService;
        }


        [Authorize(Roles = "Admin")]
        [Route("Index")]
        public IActionResult Index()
        {
            // Serilog
            _logger.LogInformation("Calling the Index action in HotelController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelIndexAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelIndexAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var hotels = _hotelRepository.AllHotels;
                return View(hotels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
            
        }

        [Route("HotelsList")]
        public IActionResult HotelsList()
        {
            // Serilog
            _logger.LogInformation("Calling the HotelsList action in HotelController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelHotelsListAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelHotelsListAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("HotelHotelsListPublicVisited") ?? 0;
                    _sessionService.SetSessionData("HotelHotelsListPublicVisited", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var hotels = _hotelRepository.AllHotels;
                return View(hotels);
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
            _logger.LogInformation("Calling the Details action in HotelController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelDetailsAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelDetailsAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("HotelDetailsPublicVisited") ?? 0;
                    _sessionService.SetSessionData("HotelDetailsPublicVisited", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var hotel = _hotelRepository.GetHotelById(id);
                if (hotel == null)
                {
                    _logger.LogInformation("The hotel variable is null...");
                    return NotFound();
                }
                return View(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
            
        }

        // GET: /Hotel/Add
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public IActionResult Add()
        {
            // Serilog
            _logger.LogInformation("Calling the Add (GET) action in HotelController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelAddAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelAddAdminVisited", adminValue + 1);
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

        // POST: /Hotel/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Add")]
        public IActionResult Add(Hotel hotel)
        {
            // Serilog
            _logger.LogInformation("Calling the Add (POST) action in HotelController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelAddAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelAddAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state is valid");

                    // Add the hotel to the database
                    _context.Hotels.Add(hotel);
                    _context.SaveChanges();

                    // Redirect to the same page
                    return RedirectToAction(nameof(Add));
                }
                return View(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
            
        }

        // GET: /Hotel/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the Edit (GET) action in HotelController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelEditAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelEditAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var hotel = _context.Hotels.Find(id);
                if (hotel == null)
                {
                    _logger.LogInformation("The hotel variable is null");
                    return NotFound();
                }

                return View(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
            
        }

        // POST: /Hotel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Edit/{id:int}")]
        public IActionResult Edit(int id, Hotel hotel)
        {
            // Serilog
            _logger.LogInformation("Calling the Edit (POST) action in HotelController");

            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelEditAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelEditAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                if (id != hotel.id)
                {
                    _logger.LogInformation("The id does not match the hotel id");
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state in the Edit action is valid");
                    _context.Hotels.Update(hotel);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Edit), new { id = hotel.id });
                }

                return View(hotel);
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
            _logger.LogInformation("Calling the Delete (GET) action in HotelController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelDeleteAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelDeleteAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }

                var hotel = _hotelRepository.GetHotelById(id);

                if (hotel == null)
                {
                    _logger.LogInformation("The hotel variable inside the Delete action is null");
                    return NotFound();
                }

                return View(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
            
        }

        // POST: /Hotel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Delete/{id:int}")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Serilog
            _logger.LogInformation("Calling the DeleteConfirmed action in HotelController");
            try
            {
                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("HotelDeleteConfirmedAdminVisited") ?? 0;
                    _sessionService.SetSessionData("HotelDeleteConfirmedAdminVisited", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                

                var hotel = _hotelRepository.GetHotelById(id);

                if (hotel == null)
                {
                    _logger.LogInformation("The hotel variable inside the DeleteConfirmed action is null");
                    return NotFound();
                }

                _hotelRepository.DeleteHotel(hotel);
                return RedirectToAction(nameof(HotelsList));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
            
        }
    }
}
