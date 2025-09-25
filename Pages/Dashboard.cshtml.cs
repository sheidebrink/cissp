using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using CisspTrainingApp.Models;

namespace CisspTrainingApp.Pages;

public class DashboardModel : PageModel
{
    private readonly ILogger<DashboardModel> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public DashboardModel(ILogger<DashboardModel> logger, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public bool ShowPassedButton { get; set; }

    public async Task OnGetAsync()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            ShowPassedButton = user?.ScheduledTestDate.HasValue == true && 
                              user.ScheduledTestDate.Value < DateTime.Now;
        }
    }
}
