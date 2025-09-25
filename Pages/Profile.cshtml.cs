using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CisspTrainingApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CisspTrainingApp.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

        public class InputModel
        {
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Display(Name = "Scheduled Test Date")]
            public DateTime? ScheduledTestDate { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // User session is stale, redirect to login
                return RedirectToPage("/Identity/Account/Login");
            }

            Input.Email = user.Email ?? string.Empty;
            Input.ScheduledTestDate = user.ScheduledTestDate;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // User session is stale, redirect to login
                return RedirectToPage("/Identity/Account/Login");
            }

            if (!ModelState.IsValid)
            {
                Input.Email = user.Email ?? string.Empty;
                return Page();
            }

            user.ScheduledTestDate = Input.ScheduledTestDate;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile.";
                return RedirectToPage();
            }

            StatusMessage = "Your profile has been updated successfully!";
            return RedirectToPage();
        }
    }
}