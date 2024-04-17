using Microsoft.AspNetCore.Mvc;
using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.ViewModels;
using SQLitePCL;

namespace GBC_Travel_Group_77.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly ICarRepository _carRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly ILogger<ShoppingCartController> _logger;
        public ShoppingCartController(IFlightRepository flightRepository, IHotelRepository hotelRepository, ICarRepository carRepository, IShoppingCart shoppingCart, ILogger<ShoppingCartController> logger)
        {
            _flightRepository = flightRepository;
            _hotelRepository = hotelRepository;
            _carRepository = carRepository;
            _shoppingCart = shoppingCart;
            _logger = logger;
        }

        public ViewResult Index()
        {
            try
            {
                _logger.LogInformation("Calling Index action");
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                var cars = new List<Car>();
                var hotels = new List<Hotel>();
                var flights = new List<Flight>();
                double total = 0;
                foreach (var item in items)
                {
                    switch (item.type.ToLower())
                    {
                        case "car":
                            var car = _carRepository.GetCarById(item.itemId);
                            if (car != null)
                            {
                                total += car.price * item.number;
                                cars.Add(car);
                            }
                            break;
                        case "hotel":
                            var hotel = _hotelRepository.GetHotelById(item.itemId);
                            if (hotel != null)
                            {
                                total += hotel.price * item.number;

                                hotels.Add(hotel);
                            }
                            break;
                        case "flight":
                            var flight = _flightRepository.GetFlightById(item.itemId);
                            if (flight != null)
                            {
                                total += flight.price * item.number;

                                flights.Add(flight);
                            }
                            break;
                        default:
                            break;
                    }
                }

                var shoppingCartViewModel = new ShoppingCartViewModel
                {
                    Cars = cars,
                    Hotels = hotels,
                    Flights = flights,
                    ShoppingCartTotal = total,
                    shoppingCart = _shoppingCart,
                };

                return View(shoppingCartViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        public RedirectToActionResult AddToShoppingCart(int id, int number, string type)
        {
            try
            {
                _logger.LogInformation("Calling AddToShoppingCart action");
                _shoppingCart.AddToCart(id, number, type);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }

        }

        //public RedirectToActionResult RemoveFromShoppingCart(int flightId)
        //{
        //    var selectedFlight = _flightRepository.AllFlights.FirstOrDefault(p => p.id == flightId);
        //    if (selectedFlight != null)
        //    {
        //        _shoppingCart.RemoveFromCart(selectedFlight);
        //    }

        //    return RedirectToAction("Index");

        //}
    }
}
