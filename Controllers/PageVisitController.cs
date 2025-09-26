using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CisspTrainingApp.Models;
using CisspTrainingApp.Data;

namespace CisspTrainingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PageVisitController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PageVisitController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> TrackPageVisit([FromBody] PageVisitRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var pageVisit = new PageVisit
            {
                UserId = user.Id,
                PageName = request.PageName,
                StartTime = DateTime.UtcNow.AddSeconds(-request.TimeSpentSeconds),
                EndTime = DateTime.UtcNow,
                TimeSpentSeconds = request.TimeSpentSeconds
            };

            _context.PageVisits.Add(pageVisit);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserPageVisits(string userId)
        {
            var visits = _context.PageVisits
                .Where(pv => pv.UserId == userId)
                .OrderByDescending(pv => pv.StartTime)
                .Take(50)
                .Select(pv => new {
                    pv.PageName,
                    pv.StartTime,
                    pv.TimeSpentSeconds
                })
                .ToList();

            return Ok(visits);
        }
    }

    public class PageVisitRequest
    {
        public string PageName { get; set; } = string.Empty;
        public int TimeSpentSeconds { get; set; }
    }
}