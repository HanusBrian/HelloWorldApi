﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cannot call await from Main method so workaround with GetAwaiter
            string message = GetMessage("Messages", 1).GetAwaiter().GetResult();
            string error = GetMessage("Messages", 5).GetAwaiter().GetResult();
            List<string> all = GetAllMessages("Messages").GetAwaiter().GetResult();
            Console.WriteLine(message);
            Console.WriteLine(error);
            Console.WriteLine();
            foreach (var m in all)
            {
                Console.WriteLine(m);
            }
            Console.ReadKey();
        }


        public static async Task<string> GetMessage(string controllerName, int id)
        {
            string result = "";
            string baseUrl = "http://localhost:50312/v1/api";
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                string resource = String.Format("{0}/{1}/{2}", baseUrl, controllerName, id);
                using (var response = await client.GetAsync(resource))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        // Response is json
                        var jsonObject = JsonConvert.DeserializeObject<Message>(responseData);
                        result = jsonObject.message;
                    }
                    else
                    {
                        result = response.StatusCode.ToString();
                    }
                }
                return result;
            }
        }

        public static async Task<List<string>> GetAllMessages(string controllerName)
        {
            List<string> result = new List<string>();
            string baseUrl = "http://localhost:50312/v1/api";
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                string resource = String.Format("{0}/{1}", baseUrl, controllerName);
                using (var response = await client.GetAsync(resource))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();

                        // Response is json
                        List<Message> jsonObjects = JsonConvert.DeserializeObject<List<Message>>(responseData);
                        foreach (var m in jsonObjects)
                        {
                            result.Add(m.message);
                        }
                    }
                    else
                    {
                        result.Add(response.StatusCode.ToString());
                    }
                }
                return result;
            }
        }
    }



    class Message
    {
        public int id { get; set; }
        public string message { get; set; }
    }
}

