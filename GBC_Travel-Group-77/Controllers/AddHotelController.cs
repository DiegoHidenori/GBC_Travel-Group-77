using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class AddHotelController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly AppDbContext _context;

        public AddHotelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Hotel/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Hotel/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                // Add the hotel to the database
                _context.Hotels.Add(hotel);
                _context.SaveChanges();

                // Redirect to the same page
                return RedirectToAction(nameof(Add));
            }
            return View(hotel);
        }
    }
}
