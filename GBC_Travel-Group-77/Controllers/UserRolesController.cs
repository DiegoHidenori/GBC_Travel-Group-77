using GBC_Travel_Group_77.Areas.ProjectManagement.Models;
using GBC_Travel_Group_77.Models.ViewModels;
using GBC_Travel_Group_77.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GBC_Travel_Group_77.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserRolesController> _logger;

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ILogger<UserRolesController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        // We give a user to it and it returns all roles of user
        private async Task<List<string>> GetUserRolesAsync(ApplicationUser user)
        {
            try
            {
                _logger.LogInformation("Calling GetUserRoles action");
                return new List<string>(await _userManager.GetRolesAsync(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error getting user roles: ", ex);
            }
        }

        // Get all the users and for each user add roles to list
        public async Task<IActionResult> Index()
        {
            try
            {
                _logger.LogInformation("Calling Index action");
                var users = await _userManager.Users.ToListAsync();
                var userRolesViewModel = new List<UserRoleViewModel>();

                foreach (ApplicationUser u in users)
                {
                    var thisViewModel = new UserRoleViewModel();
                    thisViewModel.UserId = u.Id;
                    thisViewModel.FirstName = u.FirstName;
                    thisViewModel.LastName = u.LastName;
                    thisViewModel.Email = u.Email;
                    thisViewModel.Roles = await GetUserRolesAsync(u);
                    userRolesViewModel.Add(thisViewModel);
                }
                return View(userRolesViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string userId)
        {
            try
            {
                ViewBag.userId = userId;
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                    return View("NotFound");
                }

                ViewBag.UserName = user.UserName;
                var model = new List<ManageUserRolesViewModel>();
                foreach (var role in _roleManager.Roles)
                {
                    var userRolesViewModel = new ManageUserRolesViewModel
                    {
                        RolesId = role.Id,
                        RoleName = role.Name,
                    };

                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRolesViewModel.Selected = true;
                    }
                    else
                    {
                        userRolesViewModel.Selected = false;
                    }
                    model.Add(userRolesViewModel);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(null);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> model, string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return View();
                }

                var roles = await _userManager.GetRolesAsync(user);
                var result = await _userManager.RemoveFromRolesAsync(user, roles);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user from roles");
                    return View(model);
                }

                result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add user to roles");
                    return View(model);
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
