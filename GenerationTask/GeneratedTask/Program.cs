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

        public class ImageGenerationResponse
        {
            public string ImageUrl { get; set; }
        }

        #region public static string apiKey = "";

        public static string apiKey = ""; // Write yours API Key

        #endregion

        public static string endpointURL = "https://api.openai.com/v1/completions";
        public static string imageGenerationURL = "https://api.openai.com/v1/images/generations";
        public static string modelType = "gpt-3.5-turbo-instruct";
        public static int maxTokens = 1000;
        public static double temperature = 1.0f;



        public static async Task Main(string[] args)
        {
            string response = await OpenAIComplete(apiKey, endpointURL, modelType, maxTokens, temperature);


            TextCompletionResponse question = JsonConvert.DeserializeObject<TextCompletionResponse>(response);
            string answer = question.Choices[0].Text;

            answer = answer.TrimStart();

            string prompt = answer;

            var imageResponse = await OpenAIGenerateImage(apiKey, prompt, "dall-e-3", 1, "1024x1024");

            string generatedImageUrl = imageResponse.ImageUrl;

            Console.WriteLine(answer);
            Console.WriteLine(generatedImageUrl);
        }

        // Generating task
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
        
        // Generating image
        public static async Task<ImageGenerationResponse> OpenAIGenerateImage(string apikey, string prompt, string modelType, int numImages, string imageSize)
        {
            var requestbody = new
            {
                model = modelType,
                prompt = prompt,
                n = numImages,
                size = imageSize
            };

            // Serialize the payload to JSON
            string jsonPayload = JsonConvert.SerializeObject(requestbody);

            // Create the HTTP request
            var request = new HttpRequestMessage(HttpMethod.Post, imageGenerationURL);
            request.Headers.Add("Authorization", $"Bearer {apikey}");
            request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            // Send the request and get the response
            var httpResponse = await client.SendAsync(request);
            string responseContent = await httpResponse.Content.ReadAsStringAsync();

            // Deserialize the response to get the generated image URL
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);
            string imageUrl = jsonResponse.data[0].url;

            //Console.WriteLine("Generated image URL:");
            //Console.WriteLine(imageUrl);
            //Console.WriteLine("Response from API OpenAI:");
            //Console.WriteLine(responseContent);

            // Return the ImageGenerationResponse object with the image URL
            return new ImageGenerationResponse { ImageUrl = imageUrl };
        }
    }
}