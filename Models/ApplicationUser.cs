using Microsoft.AspNetCore.Identity;

namespace CisspTrainingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? ScheduledTestDate { get; set; }
        public bool IsPassed { get; set; }
    }
}