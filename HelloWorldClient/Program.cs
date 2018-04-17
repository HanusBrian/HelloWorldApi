using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWorldApp
{
    class Program
    {
        /// <summary>
        /// This program will make a call to the HelloWorldApi 
        /// and print the first message from the API repository
        /// which will be "Hello World"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Cannot call await from Main method so workaround with GetAwaiter
            string message = GetMessage("Messages", 1).GetAwaiter().GetResult();
            Console.WriteLine(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Async method calling the HelloWorldApi 
        /// passing the name of the controller
        /// and the id of the item desired
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="id"></param>
        /// <returns>Task<string</returns>
        public static async Task<string> GetMessage(string controllerName, int id)
        {
            string result = "";
            string baseUrl = "http://localhost:50312/v1/api";
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                string resource = String.Format("{0}/{1}/{2}", baseUrl, controllerName, id);
                using (var response = await client.GetAsync(resource))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Response is json, 
                    var jsonObject = JsonConvert.DeserializeObject<Message>(responseData);
                    result = jsonObject.message;
                }
                return result;
            }
        }
    }

    /// <summary>
    /// Message object returned from API
    /// </summary>
    class Message
    {
        public int id { get; set; }
        public string message { get; set; }
    }
}
