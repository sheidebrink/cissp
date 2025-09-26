namespace CisspTrainingApp.Models
{
    public class DomainTileModel
    {
        public int Number { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Dictionary<string, int> DomainTimes { get; set; } = new();
    }
}