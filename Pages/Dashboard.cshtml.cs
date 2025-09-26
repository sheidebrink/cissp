using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using CisspTrainingApp.Models;
using CisspTrainingApp.Data;

namespace CisspTrainingApp.Pages;

public class DashboardModel : PageModel
{
    private readonly ILogger<DashboardModel> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public DashboardModel(ILogger<DashboardModel> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _logger = logger;
        _userManager = userManager;
        _context = context;
    }

    public bool ShowPassedButton { get; set; }
    public Dictionary<string, int> DomainTimes { get; set; } = new();

    public async Task OnGetAsync()
    {
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            ShowPassedButton = user?.ScheduledTestDate.HasValue == true && 
                              user.ScheduledTestDate.Value < DateTime.Now;
            
            if (user != null)
            {
                var domainVisits = _context.PageVisits
                    .Where(pv => pv.UserId == user.Id && pv.PageName.Contains("Domain"))
                    .GroupBy(pv => pv.PageName)
                    .Select(g => new { Domain = g.Key, TotalSeconds = g.Sum(pv => pv.TimeSpentSeconds) })
                    .ToList();
                
                foreach (var visit in domainVisits)
                {
                    DomainTimes[visit.Domain] = visit.TotalSeconds;
                }
            }
        }
    }
}
