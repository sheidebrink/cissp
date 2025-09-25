using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using CisspTrainingApp.Models;

namespace CisspTrainingApp.Pages.Admin
{
    public class UsersModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<ApplicationUser> Users { get; set; } = new();
        
        [BindProperty]
        public string SearchTerm { get; set; } = string.Empty;

        public void OnGet(string searchTerm = "")
        {
            SearchTerm = searchTerm;
            LoadUsers();
        }

        private void LoadUsers()
        {
            var allUsers = _userManager.Users.ToList();
            Users = string.IsNullOrEmpty(SearchTerm) 
                ? allUsers 
                : allUsers.Where(u => u.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                     u.UserName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public async Task<IActionResult> OnPostToggleUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.LockoutEnabled = !user.LockoutEnabled;
                user.LockoutEnd = user.LockoutEnabled ? DateTimeOffset.MaxValue : null;
                await _userManager.UpdateAsync(user);
            }
            return RedirectToPage(new { searchTerm = SearchTerm });
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage(new { searchTerm = SearchTerm });
        }

        public async Task<IActionResult> OnPostTogglePassed(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsPassed = !user.IsPassed;
                await _userManager.UpdateAsync(user);
            }
            return RedirectToPage(new { searchTerm = SearchTerm });
        }
    }
}