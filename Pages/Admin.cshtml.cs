using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CisspTrainingApp.Models;
using CisspTrainingApp.Services;

namespace CisspTrainingApp.Pages
{
    public class AdminModel : PageModel
    {
        private readonly QuestionService _questionService;

        public AdminModel(QuestionService questionService)
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
    }
}