namespace CisspTrainingApp.Models
{
    public class PageVisit
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string PageName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int TimeSpentSeconds { get; set; }
        
        public ApplicationUser User { get; set; } = null!;
    }
}