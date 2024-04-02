using GBC_Travel_Group_77.Data;
using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class AddCarController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly AppDbContext _context;

        public AddCarController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Car/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Car/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                // Add the car to the database
                _context.Cars.Add(car);
                _context.SaveChanges();

                // Redirect to the same page
                return RedirectToAction(nameof(Add));
            }
            return View(car);
        }
    }
}
