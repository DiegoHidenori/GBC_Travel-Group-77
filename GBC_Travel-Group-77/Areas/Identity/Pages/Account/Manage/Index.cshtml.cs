using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GBC_Travel_Group_77.Areas.ProjectManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace GBC_Travel_Group_77.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [TempData]
        public string UserChangeLimitStatusMessage { get; set; }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "First Name")]
            public string FirstName { get; set; }


            [Display(Name = "Last Name")]
            public string LastName { get; set; }


            [Display(Name = "Username")]
            public string Username { get; set; }


            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }


            // --------- Additional User Information ----------------------

            [Display(Name = "Profile Picture")]
            public byte[]? ProfilePicture { get; set; }

            [Display(Name = "Biography")]
            public string? Biography { get; set; }


            [Display(Name = "Accessibility needs")]
            public string? AccessibilityNeeds { get; set; }


            [DataType(DataType.Date)]
            [Display(Name = "Date of birth")]
            public DateOnly? DateOfBirth { get; set; }


            [Display(Name = "Address")]
            public string? Address { get; set; }


            [Display(Name = "Emergency contact")]
            public string? EmergencyContact { get; set; }


            [Display(Name = "Passport Number")]
            public string? PassportNumber { get; set; }


            [Display(Name = "Airplane seat preference")]
            public string? SeatPreference { get; set; }


            [Display(Name = "Rewards Program")]
            public string? RewardsProgram { get; set; }
        }


        // For loading the page
        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            var firstName = user.FirstName;
            var lastName = user.LastName;
            var profilePicture = user.ProfilePicture;

            //Username = userName;

            //---------------- Additional User Information ------------------
            var bio = user.Biography;
            var accessNeeds = user.AccessibilityNeeds;
            var dateOfBirth = user.DateOfBirth;
            var address = user.Address;
            var emergencyContact = user.EmergencyContact;
            var passportNum = user.PassportNumber;
            var seatPreference = user.SeatPreference;
            var rewardsProgram = user.RewardsProgram;
            //---------------------------------------------------------------

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Username = userName,
                FirstName = firstName,
                LastName = lastName,

                // ----------- Additional Info --------------------
                ProfilePicture = profilePicture,
                Biography = bio,
                AccessibilityNeeds = accessNeeds,
                DateOfBirth = dateOfBirth,
                Address = address,
                EmergencyContact = emergencyContact,
                PassportNumber = passportNum,
                SeatPreference = seatPreference,
                RewardsProgram = rewardsProgram
                // ------------------------------------------------
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            UserChangeLimitStatusMessage = $"You are permitted to change your username {user.UsernameChangeLimit} more times";

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (user.UsernameChangeLimit > 0)
            {
                if (Input.Username != user.UserName)
                {
                    var userNameExists = await _userManager.FindByNameAsync(Input.Username);
                    if (userNameExists != null)
                    {
                        StatusMessage = "Error: username already taken. Please choose a different username";
                        return RedirectToPage();
                    }
                    var setUserName = await _userManager.SetUserNameAsync(user, Input.Username);
                    if (!setUserName.Succeeded)
                    {
                        StatusMessage = "Unexpected error when trying to set the user name";
                        return RedirectToPage();
                    }

                    else
                    {
                        user.UserName = Input.Username;
                        user.UsernameChangeLimit -= 1;
                        await _userManager.UpdateAsync(user);
                    }
                }

            }

            var firstName = user.FirstName;
            if (user != null && !string.IsNullOrEmpty(Input.FirstName) && Input.FirstName != firstName)
            {
                
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }

            var lastName = user.LastName;
            if (user != null && !string.IsNullOrEmpty(Input.LastName) && Input.LastName != lastName)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }


            // ------- Additional Information --------------------------
            var biography = user.Biography;
            if (user != null && Input.Biography != biography)
            {
                if (Input.Biography == null)
                {
                    user.Biography = "";
                }
                else
                {
                    user.Biography = Input.Biography;
                }
                await _userManager.UpdateAsync(user);
            }

            var accessNeeds = user.AccessibilityNeeds;
            if (user != null && Input.AccessibilityNeeds != accessNeeds)
            {
                if (Input.AccessibilityNeeds == null)
                {
                    user.AccessibilityNeeds = "";
                }
                else
                {
                    user.AccessibilityNeeds = Input.AccessibilityNeeds;
                }
                await _userManager.UpdateAsync(user);
            }

            //var dateOfBirth = user.DateOfBirth;
            //if (user != null && !string.IsNullOrEmpty(Input.DateOfBirth) && Input.DateOfBirth != dateOfBirth)
            //{
            //    user.DateOfBirth = Input.DateOfBirth;
            //    await _userManager.UpdateAsync(user);
            //}

            if (Input.DateOfBirth != user.DateOfBirth)
            {
                if (Input.DateOfBirth == null)
                {
                    user.DateOfBirth = default;
                }
                else
                {
                    user.DateOfBirth = Input.DateOfBirth;
                }
                await _userManager.UpdateAsync(user);
            }

            var address = user.Address;
            if (user != null && Input.Address != address)
            {
                if (Input.Address == null)
                {
                    user.Address = "";
                }
                else
                {
                    user.Address = Input.Address;
                }
                await _userManager.UpdateAsync(user);
            }

            var emergencyContact = user.EmergencyContact;
            if (user != null && Input.EmergencyContact != emergencyContact)
            {
                if (Input.EmergencyContact == null)
                {
                    user.EmergencyContact = "";
                }
                else
                {
                    user.EmergencyContact = Input.EmergencyContact;
                }
                await _userManager.UpdateAsync(user);
            }

            var passportNum = user.PassportNumber;
            if (user != null && Input.PassportNumber != passportNum)
            {
                if (Input.PassportNumber == null)
                {
                    user.PassportNumber = "";
                }
                else
                {
                    user.PassportNumber = Input.PassportNumber;
                }
                await _userManager.UpdateAsync(user);
            }

            var seatPreference = user.SeatPreference;
            if (user != null && Input.SeatPreference != seatPreference)
            {
                if (Input.SeatPreference == null)
                {
                    user.SeatPreference = "";
                }
                else
                {
                    user.SeatPreference = Input.SeatPreference;
                }
                await _userManager.UpdateAsync(user);
            }

            var rewardsProgram = user.RewardsProgram;
            if (user != null && Input.RewardsProgram != rewardsProgram)
            {
                if (Input.RewardsProgram == null)
                {
                    user.RewardsProgram = "";
                }
                else
                {
                    user.RewardsProgram = Input.RewardsProgram;
                }
                await _userManager.UpdateAsync(user);
            }

            // ---------------------------------------------------------

            // Checks the image uploaded and turns it into IFormFile data type?
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    user.ProfilePicture = dataStream.ToArray();
                }
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
