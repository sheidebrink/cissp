using CisspTrainingApp.Models;

namespace CisspTrainingApp.Services
{
    public class QuestionService
    {
        private readonly List<Question> _questions = new()
        {
            // Domain 1: Security and Risk Management
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
                Text = "In the STRIDE threat model, what does the 'S' represent?",
                Options = new List<string>
                {
                    "Spoofing",
                    "Scanning",
                    "Sniffing",
                    "Social Engineering"
                },
                CorrectAnswerIndex = 0,
                Explanation = "In STRIDE, 'S' stands for Spoofing - impersonating another user or system to gain unauthorized access.",
                Domain = "Security and Risk Management"
            },
            new Question
            {
                Id = 4,
                Text = "What is the formula for calculating ALE (Annualized Loss Expectancy)?",
                Options = new List<string>
                {
                    "AV × EF",
                    "SLE × ARO",
                    "AV × ARO",
                    "EF × ARO"
                },
                CorrectAnswerIndex = 1,
                Explanation = "ALE = SLE × ARO, where SLE is Single Loss Expectancy and ARO is Annualized Rate of Occurrence.",
                Domain = "Security and Risk Management"
            },
            new Question
            {
                Id = 5,
                Text = "At which Risk Management Maturity (RMM) level is a common risk framework adopted organization-wide?",
                Options = new List<string>
                {
                    "Level 2 - Preliminary",
                    "Level 3 - Defined",
                    "Level 4 - Integrated",
                    "Level 5 - Optimized"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Level 3 (Defined) requires a common or standardized risk framework adopted organization-wide.",
                Domain = "Security and Risk Management"
            },

            // Domain 2: Asset Security
            new Question
            {
                Id = 6,
                Text = "Which of the following is NOT a private IP address range according to RFC 1918?",
                Options = new List<string>
                {
                    "10.0.0.0/8",
                    "172.16.0.0/12",
                    "192.168.0.0/16",
                    "169.254.0.0/16"
                },
                CorrectAnswerIndex = 3,
                Explanation = "169.254.0.0/16 is the APIPA (Automatic Private IP Addressing) range, not an RFC 1918 private range.",
                Domain = "Asset Security"
            },
            new Question
            {
                Id = 7,
                Text = "What is the highest classification level in the US government system?",
                Options = new List<string>
                {
                    "Confidential",
                    "Secret",
                    "Top Secret",
                    "Classified"
                },
                CorrectAnswerIndex = 2,
                Explanation = "Top Secret is the highest classification level, indicating exceptionally grave damage to national security if disclosed.",
                Domain = "Asset Security"
            },
            new Question
            {
                Id = 8,
                Text = "Which secure disposal method is most appropriate for magnetic media?",
                Options = new List<string>
                {
                    "Overwriting",
                    "Degaussing",
                    "Encryption",
                    "Physical destruction"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Degaussing uses magnetic fields to disrupt the magnetic domains on magnetic media, making data unrecoverable.",
                Domain = "Asset Security"
            },

            // Domain 3: Security Architecture and Engineering
            new Question
            {
                Id = 9,
                Text = "Which cryptographic algorithm is considered the current standard for symmetric encryption?",
                Options = new List<string>
                {
                    "DES",
                    "3DES",
                    "AES",
                    "Blowfish"
                },
                CorrectAnswerIndex = 2,
                Explanation = "AES (Advanced Encryption Standard) is the current standard for symmetric encryption, replacing DES and 3DES.",
                Domain = "Security Architecture and Engineering"
            },
            new Question
            {
                Id = 10,
                Text = "In public key cryptography, which key is used to encrypt a message for confidentiality?",
                Options = new List<string>
                {
                    "Sender's private key",
                    "Sender's public key",
                    "Recipient's private key",
                    "Recipient's public key"
                },
                CorrectAnswerIndex = 3,
                Explanation = "To ensure confidentiality, encrypt with the recipient's public key so only they can decrypt with their private key.",
                Domain = "Security Architecture and Engineering"
            },
            new Question
            {
                Id = 11,
                Text = "What is the correct order of physical security controls?",
                Options = new List<string>
                {
                    "Detect, Deter, Deny, Delay, Determine, Decide",
                    "Deter, Deny, Detect, Delay, Determine, Decide",
                    "Deny, Deter, Detect, Delay, Determine, Decide",
                    "Deter, Detect, Deny, Delay, Determine, Decide"
                },
                CorrectAnswerIndex = 1,
                Explanation = "The correct order is: Deter, Deny, Detect, Delay, Determine, Decide.",
                Domain = "Security Architecture and Engineering"
            },

            // Domain 4: Communication and Network Security
            new Question
            {
                Id = 12,
                Text = "Which email authentication protocol uses cryptographic signatures?",
                Options = new List<string>
                {
                    "SPF",
                    "DKIM",
                    "DMARC",
                    "SMTP"
                },
                CorrectAnswerIndex = 1,
                Explanation = "DKIM (DomainKeys Identified Mail) uses cryptographic signatures to verify email hasn't been tampered with.",
                Domain = "Communication and Network Security"
            },
            new Question
            {
                Id = 13,
                Text = "What is the major vulnerability in WEP wireless security?",
                Options = new List<string>
                {
                    "Weak passwords",
                    "24-bit initialization vector",
                    "No encryption",
                    "Open authentication"
                },
                CorrectAnswerIndex = 1,
                Explanation = "WEP's 24-bit IV is too short, causing key reuse and making it easily crackable.",
                Domain = "Communication and Network Security"
            },
            new Question
            {
                Id = 14,
                Text = "Which OSI layer is responsible for routing?",
                Options = new List<string>
                {
                    "Layer 2 - Data Link",
                    "Layer 3 - Network",
                    "Layer 4 - Transport",
                    "Layer 5 - Session"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Layer 3 (Network) handles routing and logical addressing using protocols like IP.",
                Domain = "Communication and Network Security"
            },

            // Domain 5: Identity and Access Management
            new Question
            {
                Id = 15,
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
            },
            new Question
            {
                Id = 16,
                Text = "What are the three factors of authentication?",
                Options = new List<string>
                {
                    "Username, password, token",
                    "Something you know, have, are",
                    "Local, remote, federated",
                    "Read, write, execute"
                },
                CorrectAnswerIndex = 1,
                Explanation = "The three authentication factors are: something you know (password), something you have (token), something you are (biometric).",
                Domain = "Identity and Access Management"
            },
            new Question
            {
                Id = 17,
                Text = "Which EAP method is considered most secure for wireless authentication?",
                Options = new List<string>
                {
                    "EAP-TLS",
                    "EAP-TTLS",
                    "PEAP",
                    "EAP-FAST"
                },
                CorrectAnswerIndex = 0,
                Explanation = "EAP-TLS is most secure as it uses mutual certificate authentication between client and server.",
                Domain = "Identity and Access Management"
            },

            // Domain 6: Security Assessment and Testing
            new Question
            {
                Id = 18,
                Text = "What CVSS score range indicates a CRITICAL vulnerability?",
                Options = new List<string>
                {
                    "7.0-8.9",
                    "9.0-10.0",
                    "4.0-6.9",
                    "0.1-3.9"
                },
                CorrectAnswerIndex = 1,
                Explanation = "CVSS scores of 9.0-10.0 indicate CRITICAL vulnerabilities requiring immediate action.",
                Domain = "Security Assessment and Testing"
            },
            new Question
            {
                Id = 19,
                Text = "What is the difference between vulnerability assessment and penetration testing?",
                Options = new List<string>
                {
                    "No difference, they are the same",
                    "Vulnerability assessment identifies weaknesses, penetration testing exploits them",
                    "Penetration testing is automated, vulnerability assessment is manual",
                    "Vulnerability assessment is more comprehensive"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Vulnerability assessment identifies security weaknesses, while penetration testing actively exploits vulnerabilities to demonstrate impact.",
                Domain = "Security Assessment and Testing"
            },
            new Question
            {
                Id = 20,
                Text = "In penetration testing, what does 'black box' testing mean?",
                Options = new List<string>
                {
                    "Testing with full system knowledge",
                    "Testing with no internal knowledge",
                    "Testing only network components",
                    "Testing with limited knowledge"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Black box testing simulates an external attacker with no internal knowledge of the system.",
                Domain = "Security Assessment and Testing"
            },

            // Domain 7: Security Operations
            new Question
            {
                Id = 21,
                Text = "Which fire suppression system is most appropriate for data centers?",
                Options = new List<string>
                {
                    "Water sprinklers",
                    "Dry chemical",
                    "Clean agent (FM-200)",
                    "Foam"
                },
                CorrectAnswerIndex = 2,
                Explanation = "Clean agents like FM-200 are preferred for data centers as they don't damage equipment and are safe for occupied spaces.",
                Domain = "Security Operations"
            },
            new Question
            {
                Id = 22,
                Text = "What backup type requires the most storage space but provides fastest recovery?",
                Options = new List<string>
                {
                    "Incremental",
                    "Differential",
                    "Full",
                    "Snapshot"
                },
                CorrectAnswerIndex = 2,
                Explanation = "Full backups require the most storage space but provide the fastest recovery since all data is in one backup set.",
                Domain = "Security Operations"
            },
            new Question
            {
                Id = 23,
                Text = "Which malware type is designed to hide its presence in the system?",
                Options = new List<string>
                {
                    "Virus",
                    "Worm",
                    "Rootkit",
                    "Trojan"
                },
                CorrectAnswerIndex = 2,
                Explanation = "Rootkits are specifically designed to hide their presence and maintain persistent access to systems.",
                Domain = "Security Operations"
            },

            // Domain 8: Software Development Security
            new Question
            {
                Id = 24,
                Text = "Which vulnerability is prevented by using parameterized queries?",
                Options = new List<string>
                {
                    "Cross-Site Scripting (XSS)",
                    "SQL Injection",
                    "Buffer Overflow",
                    "Cross-Site Request Forgery (CSRF)"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Parameterized queries prevent SQL injection by separating SQL code from user input data.",
                Domain = "Software Development Security"
            },
            new Question
            {
                Id = 25,
                Text = "What is the #1 vulnerability in the OWASP Top 10?",
                Options = new List<string>
                {
                    "Broken Authentication",
                    "Injection",
                    "Sensitive Data Exposure",
                    "Cross-Site Scripting"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Injection vulnerabilities, particularly SQL injection, are ranked #1 in the OWASP Top 10.",
                Domain = "Software Development Security"
            },
            new Question
            {
                Id = 26,
                Text = "Which secure coding practice prevents buffer overflow attacks?",
                Options = new List<string>
                {
                    "Input validation",
                    "Output encoding",
                    "Bounds checking",
                    "Error handling"
                },
                CorrectAnswerIndex = 2,
                Explanation = "Bounds checking ensures that data written to buffers doesn't exceed the allocated memory space, preventing buffer overflows.",
                Domain = "Software Development Security"
            }
        };

        public List<Question> GetRandomQuestions(int count = 10, string? domain = null)
        {
            var filteredQuestions = string.IsNullOrEmpty(domain) 
                ? _questions 
                : _questions.Where(q => q.Domain == domain).ToList();
            
            return filteredQuestions.OrderBy(x => Guid.NewGuid()).Take(count).ToList();
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

        public async Task<object> GenerateQuestionWithNova()
        {
            var novaService = new NovaService();
            var question = await novaService.GenerateQuestion();
            
            return new
            {
                text = question.Text,
                domain = question.Domain,
                options = question.Options,
                correctAnswerIndex = question.CorrectAnswerIndex,
                explanation = question.Explanation
            };
        }
    }
}