using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MechanicClient.DataProviders
{
    class JobDataProvider
    {
        private const string _url = "http://localhost:5000/api/mechanicclient";

        public static IEnumerable<Job> GetJobs()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(rawData);
                    return jobs;
                }
                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void UpdateJob(Job job)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(job);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");
                var response = client.PutAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
