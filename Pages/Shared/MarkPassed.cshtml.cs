using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using CisspTrainingApp.Models;

namespace CisspTrainingApp.Pages.Shared
{
    public class MarkPassedModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MarkPassedModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.IsPassed = true;
                    await _userManager.UpdateAsync(user);
                }
            }
            return RedirectToPage("/Dashboard");
        }
    }
}