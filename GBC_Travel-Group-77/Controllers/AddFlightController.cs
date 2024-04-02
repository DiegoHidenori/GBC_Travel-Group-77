using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class AddFlightController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly AppDbContext _context;

        public AddFlightController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Flight/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Flight/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Flight flight)
        {
            if (ModelState.IsValid)
            {
                // Add the hotel to the database
                _context.Flights.Add(flight);
                _context.SaveChanges();

                // Redirect to the same page
                return RedirectToAction(nameof(Add));
            }
            return View(flight);
        }
    }
}
