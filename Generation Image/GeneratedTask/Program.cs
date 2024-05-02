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

        public class ImageGenerationResponse
        {
            public string ImageUrl { get; set; }
        }

        #region public static string apiKey = "";

        public static string apiKey = ""; // Write yours API Key

        #endregion

        public static string imageGenerationURL = "https://api.openai.com/v1/images/generations";
        public static string modelImages = "dall-e-3";
        public static string sizeImages = "1024x1024";
        public static int numImages = 1;
        public static double temperature = 0.1f;

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Enter your request:");

            string prompt = Console.ReadLine(); //Can write your own prompt

            var imageResponse = await OpenAIGenerateImage(apiKey, prompt, modelImages, numImages, sizeImages);

            string generatedImageUrl = imageResponse.ImageUrl;

            Console.WriteLine(generatedImageUrl);
        }

        // Generating image func
        public static async Task<ImageGenerationResponse> OpenAIGenerateImage(string apikey, string prompt, string modelText, int numImages, string imageSize)
        {
            var requestbody = new
            {
                model = modelText,
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

            // Return the ImageGenerationResponse object with the image URL
            return new ImageGenerationResponse { ImageUrl = imageUrl };
        }
    }
}