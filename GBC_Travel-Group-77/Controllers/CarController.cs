using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class CarController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly ICarRepository _carRepository;
        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IActionResult CarsList()
        {
            var cars = _carRepository.AllCars;
            return View(cars);
        }

        public IActionResult Details(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }
    }
}
