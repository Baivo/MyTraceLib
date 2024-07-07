using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI;
using MyTraceLib.Tables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace MyTraceLib.Services
{
    public static class AiService
    {
        private static readonly OpenAIService sdk = new OpenAIService(new OpenAiOptions()
        {
            ApiKey = "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"
        });
        public static async Task<IngredientBreakdown> GetIngredientBreakdownAsync(string ingredient)
        {
            List<ChatMessage> messages = new();
            messages.Add(ChatMessage.FromSystem(@"Provide a detailed breakdown of the ingredient [Ingredient] in the following format, matching this C# class structure:
            {
                private string IngredientBreakdownId { get; set; } = Guid.NewGuid().ToString();
                [StringLength(250)]
                public string IngredientName { get; set; } = string.Empty;
                public string Purpose { get; set; } = string.Empty;
                public string Source { get; set; } = string.Empty;
                public string Toxicity { get; set; } = string.Empty;
                public string CarcinogenicProperties { get; set; } = string.Empty;
                public List<string> HealthierAlternatives { get; set; } = new List<string>();
                public List<string> CommonUses { get; set; } = new List<string>();
                public string RegulatoryStatusInAustralia { get; set; } = string.Empty;
                public string EnvironmentalImpact { get; set; } = string.Empty;
            }

            Ignore the IngredientBreakdownId property and provide the response in JSON format without backticks or any additional characters. Provide as much information as you can. Assume maximum skepticism for the ingredient, deliver information objectivelty with no passive language. Do not include information from any body/firm/group/institute/authority etc. outside of the regulary approval category."));

            messages.Add(ChatMessage.FromUser($"[Ingredient] = {ingredient}"));

            var completionResult = await sdk.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = messages,
                Model = Models.Gpt_4o,
                MaxTokens = 400
            });

            if (completionResult.Successful)
            {
                var msg = completionResult.Choices.First().Message.Content;

                try
                {
                    // Validate if the response is a valid JSON
                    if (IsValidJson(msg))
                    {
                        var breakdown = JsonConvert.DeserializeObject<IngredientBreakdown>(msg);
                        return breakdown;
                    }
                    else
                    {
                        Console.WriteLine("The response is not a valid JSON.");
                        return null;
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("JSON Deserialization error: " + ex.Message);
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Generation Failure");
                return null;
            }
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || // For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) // For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception) // Some other exception
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
