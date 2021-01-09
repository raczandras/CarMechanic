using JobManager_Server.Repositories;
using JobManagerClient;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JobManager_Server.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            var jobs = JobRepository.GetJobs();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public ActionResult<Job> Get(int id)
        {
            var jobs = JobRepository.GetJobs();
            var job = jobs.FirstOrDefault(job => job.Id == id);
            if(job != null)
            {
                return Ok(job);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Job job)
        {
            var jobs = JobRepository.GetJobs().ToList();

            job.Id = GetNewId(jobs);
            jobs.Add(job);

            JobRepository.StoreJobs(jobs);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Job job)
        {
            var jobs = JobRepository.GetJobs().ToList();

            var jobToUpdate = jobs.FirstOrDefault(p => p.Id == job.Id);
            if (jobToUpdate != null)
            {
                jobToUpdate.Name = job.Name;
                jobToUpdate.LicensePlate = job.LicensePlate;
                jobToUpdate.CarType = job.CarType;
                jobToUpdate.Date = job.Date;
                jobToUpdate.Failure = job.Failure;

                JobRepository.StoreJobs(jobs);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var jobs = JobRepository.GetJobs().ToList();

            var jobToDelete = jobs.FirstOrDefault(job => job.Id == id);
            if (jobToDelete != null)
            {
                jobs.Remove(jobToDelete);

                JobRepository.StoreJobs(jobs);
                return Ok();
            }

            return NotFound();
        }

        private int GetNewId(IEnumerable<Job> jobs)
        {
            int newId = 0;
            foreach (var job in jobs)
            {
                if (newId < job.Id)
                {
                    newId = job.Id;
                }
            }
            return newId + 1;
        }
    }
}
