// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GBC_Travel_Group_77.Areas.ProjectManagement.Models;
using System.Net.Mail;

namespace GBC_Travel_Group_77.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<ApplicationUser> _userManager;


        /* 
         * April 8: SignInManager, Logger, and UserManager are injected here to use throughout the class. This is called
         * dependency injection
         */
        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
        }

        
        [BindProperty]
        public InputModel Input { get; set; }

 
        public IList<AuthenticationScheme> ExternalLogins { get; set; }


        public string ReturnUrl { get; set; }


        [TempData]
        public string ErrorMessage { get; set; }


        /*
         * April 8: This InputModel class represents the data submitted by the user in the login form. It 
         * contains the properties for email and password.
         */
        public class InputModel
        {
            [Required]
            [Display(Name ="Email / Username")]
            public string Email { get; set; }


            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }


        /*
         * April 8: OnGetAsync method is called when user navigates to the login page. It initializes the state of the page 
         * plus error messages.
         */
        public async Task OnGetAsync(string returnUrl = null)
        {
            try
            {
                _logger.LogInformation("Calling the OnGetAsync action in LoginModel");
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    _logger.LogInformation("The error message is not null or empty");
                    ModelState.AddModelError(string.Empty, ErrorMessage);
                }

                returnUrl ??= Url.Content("~/");

                // Clear the existing external cookie to ensure a clean login process
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                ReturnUrl = returnUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }


        /*
         * April 8: OnPostAsync method is called when the user submits the login form. It validates form data and then 
         * tries to sign in the user with the SignInManager. If the sign-in works, the user is redirected to the returnUrl. 
         * If not, it shows an error.
         */
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
                _logger.LogInformation("Calling the OnPostAsync action in LoginModel");
                returnUrl ??= Url.Content("~/");

                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

                if (ModelState.IsValid)
                {
                    _logger.LogInformation("The model state is valid");
                    var userName = Input.Email;
                    if (isValidEmail(Input.Email))
                    {
                        _logger.LogInformation("The email is a valid email");
                        var user = await _userManager.FindByEmailAsync(Input.Email);
                        if (user != null)
                        {
                            _logger.LogInformation("The user is not null");
                            userName = user.UserName;
                        }
                    }
                    //var user = await _userManager.FindByEmailAsync(Input.Email);
                    ////_logger.LogInformation($"Email submitted: {Input.Email}");
                    //if (user == null)
                    //{
                    //    // User with the provided email does not exist
                    //    ModelState.AddModelError(string.Empty, "Invalid login attempt. User with email does not exist");
                    //    return Page();
                    //}


                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                    var result = await _signInManager.PasswordSignInAsync(userName, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    _logger.LogInformation($"Email: {Input.Email}. Password: {Input.Password}");
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                    if (result.RequiresTwoFactor)
                    {
                        _logger.LogInformation("The user required two-factor authentication");
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }

                // If we got this far, something failed, redisplay form
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }


        /*
         * April 8: isValidEmail method is a helper function to check whether the email is valid.
         */
        public bool isValidEmail(string emailAddress)
        {
            try
            {
                _logger.LogInformation("Calling the isValidEmail action in LoginModel");
                var MailAddress = new MailAddress(emailAddress);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
