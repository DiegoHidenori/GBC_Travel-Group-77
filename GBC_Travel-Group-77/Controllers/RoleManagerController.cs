using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel_Group_77.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleManagerController> _logger;
        private readonly ISessionService _sessionService;

        public RoleManagerController(RoleManager<IdentityRole> roleManager, ILogger<RoleManagerController> logger, ISessionService sessionService)
        {
            _roleManager = roleManager;
            _logger = logger;
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Calling RoleManager Index action");

                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("RoleManagerAdmin") ?? 0;
                    _sessionService.SetSessionData("RoleManagerAdmin", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("RoleManagerAdmin") ?? 0;
                    _sessionService.SetSessionData("RoleManagerAdmin", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                var roles = await _roleManager.Roles.ToListAsync();
                return View(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoles(string roleName)
        {
            try
            {
                _logger.LogInformation("Calling RoleManager AddRoles action");

                // Session service
                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("The current user has the Admin role");
                    var adminValue = _sessionService.GetSessionData<int?>("RoleManAddRolesAdmin") ?? 0;
                    _sessionService.SetSessionData("RoleManAddRolesAdmin", adminValue + 1);
                    ViewBag.adminsession = adminValue + 1;
                }
                else
                {
                    _logger.LogInformation("The current user does not have the Admin role");
                    var publicValue = _sessionService.GetSessionData<int?>("RoleManAddRolesPublic") ?? 0;
                    _sessionService.SetSessionData("RoleManAddRolesPublic", publicValue + 1);
                    ViewBag.publicsession = publicValue + 1;
                }

                if (roleName != null)
                {
                    _logger.LogInformation("Role name is not null");
                    await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }
    }
}
