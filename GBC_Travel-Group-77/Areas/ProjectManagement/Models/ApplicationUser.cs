using Microsoft.AspNetCore.Identity;

namespace GBC_Travel_Group_77.Areas.ProjectManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UsernameChangeLimit { get; set; } = 10;
        public byte[]? ProfilePicture { get; set; }


        // ----- Additional Information -----------
        public string? Biography { get; set; }
        public string? AccessibilityNeeds { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? EmergencyContact { get; set; }
        public string? PassportNumber { get; set; }
        public string? SeatPreference { get; set; }
        public string? RewardsProgram { get; set; }
    }
}
