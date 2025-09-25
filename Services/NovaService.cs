using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;
using Amazon.Runtime.CredentialManagement;
using System.Text.Json;
using CisspTrainingApp.Models;

namespace CisspTrainingApp.Services
{
    public class NovaService
    {
        private readonly AmazonBedrockRuntimeClient _bedrockClient;

        public NovaService()
        {
            var chain = new Amazon.Runtime.CredentialManagement.CredentialProfileStoreChain();
            if (chain.TryGetAWSCredentials("cissp-app", out var credentials))
            {
                _bedrockClient = new AmazonBedrockRuntimeClient(credentials, Amazon.RegionEndpoint.USEast1);
            }
            else
            {
                _bedrockClient = new AmazonBedrockRuntimeClient(Amazon.RegionEndpoint.USEast1);
            }
        }

        public async Task<Question> GenerateQuestion()
        {
            var prompt = @"Generate a CISSP exam question in JSON format with the following structure:
{
  ""text"": ""Question text here"",
  ""domain"": ""One of: Security and Risk Management, Asset Security, Security Architecture and Engineering, Communication and Network Security, Identity and Access Management, Security Assessment and Testing, Security Operations, Software Development Security"",
  ""options"": [""Option A"", ""Option B"", ""Option C"", ""Option D""],
  ""correctAnswerIndex"": 0,
  ""explanation"": ""Detailed explanation of the correct answer""
}

Make it a realistic CISSP-level question with plausible distractors. Return only valid JSON.";

            var request = new InvokeModelRequest
            {
                ModelId = "amazon.nova-lite-v1:0",
                ContentType = "application/json",
                Body = new MemoryStream(JsonSerializer.SerializeToUtf8Bytes(new
                {
                    messages = new[]
                    {
                        new { role = "user", content = new[] { new { text = prompt } } }
                    },
                    inferenceConfig = new
                    {
                        maxTokens = 1000,
                        temperature = 0.7
                    }
                }))
            };

            var response = await _bedrockClient.InvokeModelAsync(request);
            var responseBody = await JsonSerializer.DeserializeAsync<JsonElement>(response.Body);
            var content = responseBody.GetProperty("output").GetProperty("message").GetProperty("content")[0].GetProperty("text").GetString();

            // Extract JSON from markdown code blocks if present
            var jsonContent = content;
            if (content.Contains("```json"))
            {
                var startIndex = content.IndexOf("```json") + 7;
                var endIndex = content.IndexOf("```", startIndex);
                if (endIndex > startIndex)
                {
                    jsonContent = content.Substring(startIndex, endIndex - startIndex).Trim();
                }
            }
            else if (content.Contains("```"))
            {
                var startIndex = content.IndexOf("```") + 3;
                var endIndex = content.IndexOf("```", startIndex);
                if (endIndex > startIndex)
                {
                    jsonContent = content.Substring(startIndex, endIndex - startIndex).Trim();
                }
            }

            return JsonSerializer.Deserialize<Question>(jsonContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}