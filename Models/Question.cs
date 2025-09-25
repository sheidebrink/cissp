namespace CisspTrainingApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
    }
}