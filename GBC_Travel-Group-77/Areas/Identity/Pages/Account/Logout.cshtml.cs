// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using GBC_Travel_Group_77.Areas.ProjectManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GBC_Travel_Group_77.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            try
            {
                _logger.LogInformation("Calling the OnPost action in LogoutModel");
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                if (returnUrl != null)
                {
                    _logger.LogInformation("The return URL is not null");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    _logger.LogInformation("The return URL is null");
                    // This needs to be a redirect so that the browser performs a new
                    // request and the identity for the user gets updated.
                    return RedirectToPage();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception("Error: ", ex);
            }
        }
    }
}
