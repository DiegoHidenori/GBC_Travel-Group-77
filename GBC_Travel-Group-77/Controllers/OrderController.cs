using GBC_Travel_Group_77.Models;
using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    public class OrderController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        private readonly ILogger<OrderController> _logger;
        private readonly ISessionService _sessionService;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart, ILogger<OrderController> logger, ISessionService sessionService)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _logger = logger;
            _sessionService = sessionService;
        }

        // GET: /<controller>/
        public IActionResult Checkout()//get
        {
            try
            {
                _logger.LogInformation("Calling Order Checkout (GET) action");

                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("OrderCheckoutAdmin") ?? 0;
                    _sessionService.SetSessionData("OrderCheckoutAdmin", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("OrderCheckoutPublic") ?? 0;
                    _sessionService.SetSessionData("OrderCheckoutPublic", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            try
            {
                _logger.LogInformation("Calling Order Checkout (POST) action");

                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("OrderCheckoutAdmin") ?? 0;
                    _sessionService.SetSessionData("OrderCheckoutAdmin", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("OrderCheckoutPublic") ?? 0;
                    _sessionService.SetSessionData("OrderCheckoutPublic", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                if (_shoppingCart.ShoppingCartItems.Count == 0)
                {
                    _logger.LogInformation("There are 0 items in the shopping cart");
                    ModelState.AddModelError("", "Your cart is empty, add some items first!");
                }

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state is valid");
                    _orderRepository.CreateOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");

                }
                return View(order);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        public IActionResult CheckoutComplete()
        {
            try
            {
                _logger.LogInformation("Calling Order CheckoutComplete action");

                // Session service
                var Value = _sessionService.GetSessionData<int?>("OrderCheckoutComplete") ?? 0;
                _sessionService.SetSessionData("OrderCheckoutComplete", Value + 1);
                ViewBag.session = Value + 1;

                ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy your best trip";
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }
    }
}
