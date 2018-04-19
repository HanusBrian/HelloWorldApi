using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldClient
{
    public static class Api
    {
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

        public static async Task<string> PostMessage(string controllerName, string message)
        {
            string result = "";
            string baseUrl = "http://localhost:50312/v1/api";
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                string resource = String.Format("{0}/{1}", baseUrl, controllerName);
                using (var response = await client.PostAsync(resource,
                                                        new StringContent(JsonConvert.SerializeObject(message),
                                                        Encoding.UTF8,
                                                        "application/json")))
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

        public static async Task<string> DeleteMessage(string controllerName, int id)
        {
            string result = "";
            string baseUrl = "http://localhost:50312/v1/api";
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                string resource = String.Format("{0}/{1}/{2}", baseUrl, controllerName, id);
                using (var response = await client.DeleteAsync(resource))
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

        public static async Task<string> PutMessage(string controllerName, int id, string message)
        {
            string result = "";
            string baseUrl = "http://localhost:50312/v1/api";
            using (var client = new HttpClient { BaseAddress = new Uri(baseUrl) })
            {
                string resource = String.Format("{0}/{1}/{2}", baseUrl, controllerName, id);
                using (var response = await client.PutAsync(resource,
                                                        new StringContent(JsonConvert.SerializeObject(message),
                                                        Encoding.UTF8,
                                                        "application/json")))
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
                        if(response.StatusCode == System.Net.HttpStatusCode.OK)
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
