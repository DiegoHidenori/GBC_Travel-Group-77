using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Mvc;

namespace GBC_Travel_Group_77.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        //Serilog
        private readonly ILogger<HotelController> _logger;
        private readonly ISessionService _sessionService;

        public ContactController(ILogger<HotelController> logger, ISessionService sessionService)
        {
            _logger = logger;
            _sessionService = sessionService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            _logger.LogInformation("Calling the Index action in ContactController");
            try
            {
                // Session service
                var publicValue = _sessionService.GetSessionData<int?>("ContactIndexPublicVisited") ?? 0;
                _sessionService.SetSessionData("ContactIndexPublicVisited", publicValue + 1);
                ViewBag.publicsession = publicValue + 1;

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
