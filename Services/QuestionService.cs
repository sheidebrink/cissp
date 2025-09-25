using CisspTrainingApp.Models;

namespace CisspTrainingApp.Services
{
    public class QuestionService
    {
        private readonly List<Question> _questions = new()
        {
            new Question
            {
                Id = 1,
                Text = "Which of the following is the PRIMARY purpose of risk assessment?",
                Options = new List<string>
                {
                    "To eliminate all risks",
                    "To identify and evaluate potential threats and vulnerabilities",
                    "To implement security controls",
                    "To create security policies"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Risk assessment primarily identifies and evaluates potential threats and vulnerabilities to determine their impact on the organization.",
                Domain = "Security and Risk Management"
            },
            new Question
            {
                Id = 2,
                Text = "What does the 'A' in the CIA triad represent?",
                Options = new List<string>
                {
                    "Authentication",
                    "Authorization",
                    "Availability",
                    "Accountability"
                },
                CorrectAnswerIndex = 2,
                Explanation = "The CIA triad consists of Confidentiality, Integrity, and Availability - the three fundamental principles of information security.",
                Domain = "Security and Risk Management"
            },
            new Question
            {
                Id = 3,
                Text = "Which access control model uses labels and clearances?",
                Options = new List<string>
                {
                    "Discretionary Access Control (DAC)",
                    "Mandatory Access Control (MAC)",
                    "Role-Based Access Control (RBAC)",
                    "Attribute-Based Access Control (ABAC)"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Mandatory Access Control (MAC) uses security labels and clearances to control access to resources based on classification levels.",
                Domain = "Identity and Access Management"
            }
        };

        public List<Question> GetRandomQuestions(int count = 10)
        {
            return _questions.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
        }

        public Question? GetQuestionById(int id)
        {
            return _questions.FirstOrDefault(q => q.Id == id);
        }

        public List<Question> GetAllQuestions()
        {
            return _questions;
        }

        public void AddQuestion(Question question)
        {
            question.Id = _questions.Count > 0 ? _questions.Max(q => q.Id) + 1 : 1;
            question.Options = question.Options ?? new List<string>();
            _questions.Add(question);
        }

        public void DeleteQuestion(int id)
        {
            var question = _questions.FirstOrDefault(q => q.Id == id);
            if (question != null)
            {
                _questions.Remove(question);
            }
        }
    }
}