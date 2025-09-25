using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CisspTrainingApp.Models;
using CisspTrainingApp.Services;

namespace CisspTrainingApp.Pages
{
    public class QuizModel : PageModel
    {
        private readonly QuestionService _questionService;

        public QuizModel(QuestionService questionService)
        {
            _questionService = questionService;
        }

        public List<Question> Questions { get; set; } = new();
        public int CurrentQuestionIndex { get; set; } = 0;
        public int Score { get; set; } = 0;
        public bool ShowAnswer { get; set; } = false;
        public bool LastAnswerCorrect { get; set; } = false;

        public void OnGet(string? domain = null)
        {
            Questions = _questionService.GetRandomQuestions(3, domain);
            HttpContext.Session.SetString("Questions", System.Text.Json.JsonSerializer.Serialize(Questions));
            
            if (!string.IsNullOrEmpty(domain))
            {
                ViewData["Title"] = $"CISSP Quiz - {domain}";
            }
        }

        public IActionResult OnPost(int currentQuestionIndex, int selectedAnswer)
        {
            var questionsJson = HttpContext.Session.GetString("Questions");
            if (questionsJson != null)
            {
                Questions = System.Text.Json.JsonSerializer.Deserialize<List<Question>>(questionsJson) ?? new();
            }

            CurrentQuestionIndex = currentQuestionIndex;
            
            if (CurrentQuestionIndex < Questions.Count)
            {
                var question = Questions[CurrentQuestionIndex];
                LastAnswerCorrect = selectedAnswer == question.CorrectAnswerIndex;
                
                if (LastAnswerCorrect)
                {
                    Score = int.Parse(HttpContext.Session.GetString("Score") ?? "0") + 1;
                    HttpContext.Session.SetString("Score", Score.ToString());
                }
                else
                {
                    Score = int.Parse(HttpContext.Session.GetString("Score") ?? "0");
                }

                ShowAnswer = true;
            }

            return Page();
        }

        public IActionResult OnPostNext(int currentQuestionIndex, int score)
        {
            var questionsJson = HttpContext.Session.GetString("Questions");
            if (questionsJson != null)
            {
                Questions = System.Text.Json.JsonSerializer.Deserialize<List<Question>>(questionsJson) ?? new();
            }

            CurrentQuestionIndex = currentQuestionIndex;
            Score = score;
            ShowAnswer = false;
            
            HttpContext.Session.SetString("Score", Score.ToString());

            return Page();
        }
    }
}