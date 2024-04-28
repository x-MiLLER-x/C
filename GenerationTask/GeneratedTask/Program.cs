using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace GeneratedTask
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public class Choice
        {
            public string Text { get; set; }
        }

        public class TextCompletionResponse
        {
            public Choice[] Choices { get; set; }
        }

        #region public static string apiKey = "";

        public static string apiKey = ""; // Write yours API Key

        #endregion

        public static string endpointURL = "https://api.openai.com/v1/completions";
        public static string modelType = "gpt-3.5-turbo-instruct";
        public static int maxTokens = 1000;
        public static double temperature = 1.0f;



        public static async Task Main(string[] args)
        {
            string response = await OpenAIComplete(apiKey, endpointURL, modelType, maxTokens, temperature);
            

            TextCompletionResponse question = JsonConvert.DeserializeObject<TextCompletionResponse>(response);
            string answer = question.Choices[0].Text;

            answer = answer.TrimStart();
            
            Console.WriteLine(answer);
        }


        public static async Task<string> OpenAIComplete(string apikey, string endpoint, string modeltype, int maxtokens, double temp)
        {
            var requestbody = new
            {
                model = modeltype,
                prompt = "What is AI?",
                max_tokens = maxtokens,
                temperature = temp
            };

            // Serialize the payload to JSON
            string jsonPayload = JsonConvert.SerializeObject(requestbody);

            // Create the HTTP request
            var request = new HttpRequestMessage(HttpMethod.Post, endpointURL);
            request.Headers.Add("Authorization", $"Bearer {apikey}");
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Send the request and get the response
            var httpResponse = await client.SendAsync(request);
            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            return responseContent;
        }
    }
}