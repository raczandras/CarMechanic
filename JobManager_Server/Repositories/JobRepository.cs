using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JobManagerClient;

namespace JobManager_Server.Repositories
{
    public static class JobRepository
    {
        private const string filename = "Jobs.json";

        public static IEnumerable<Job> GetJobs()
        {
            if (File.Exists(filename))
            {
                var rawData = File.ReadAllText(filename);
                var jobs = JsonSerializer.Deserialize<IEnumerable<Job>>(rawData);
                return jobs;
            }

            return new List<Job>();
        }

        public static void StoreJobs(IEnumerable<Job> job)
        {
            var rawData = JsonSerializer.Serialize(job);
            File.WriteAllText(filename, rawData);
        }
    }
}
