/*using Newtonsoft.Json;*/
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JobManagerClient.DataProviders
{
    class JobDataProvider
    {
        private const string _url = "http://localhost:44378/api/job";

        public static IEnumerable<Job> GetJobs()
        {
            using(var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var jobs = JsonSerializer.Deserialize<IEnumerable<Job>>(rawData);
                    return jobs;
                }
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }


        public static void CreateJob(Job job)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonSerializer.Serialize(job);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");
                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdateJob(Job job)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonSerializer.Serialize(job);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");
                var response = client.PutAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeleteJob(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
