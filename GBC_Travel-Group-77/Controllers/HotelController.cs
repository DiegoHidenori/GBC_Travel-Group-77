using GBC_Travel_Group_77.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class HotelController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public IActionResult HotelsList()
        {
            var hotels = _hotelRepository.AllHotels;
            return View(hotels);
        }

        public IActionResult Details(int id)
        {
            var hotel = _hotelRepository.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }
    }
}
