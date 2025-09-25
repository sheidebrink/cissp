using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CisspTrainingApp.Models;
using CisspTrainingApp.Services;

namespace CisspTrainingApp.Pages.Admin
{
    public class QuestionsModel : PageModel
    {
        private readonly QuestionService _questionService;

        public QuestionsModel(QuestionService questionService)
        {
            _questionService = questionService;
        }

        public List<Question> Questions { get; set; } = new();

        [BindProperty]
        public Question NewQuestion { get; set; } = new();

        public void OnGet()
        {
            Questions = _questionService.GetAllQuestions();
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid)
            {
                _questionService.AddQuestion(NewQuestion);
                return RedirectToPage();
            }
            Questions = _questionService.GetAllQuestions();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _questionService.DeleteQuestion(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostGenerateQuestion()
        {
            try
            {
                var question = await _questionService.GenerateQuestionWithNova();
                return new JsonResult(question);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}