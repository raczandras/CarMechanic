using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagerClient;
using JobManager_Server.Repositories;


namespace JobManager_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobManagerController : ControllerBase
    {
        // GET: api/<JobController>
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            return Ok(JobManagerRepository.GetJobs());
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public ActionResult<Job> Get(int id)
        {
            var jobs = JobManagerRepository.GetJobs();
            var job =  jobs.FirstOrDefault(x => x.Id == id);
            if(job != null)
            {
                return Ok(job);
            }

            return NotFound();
        }

        // POST api/<JobController>
        [HttpPost]
        public ActionResult Post([FromBody] Job job)
        {
            List<Job> jobs = (List<Job>)JobManagerRepository.GetJobs();
            job.Id = GetewId(jobs);
            jobs.Add(job);
            JobManagerRepository.StoreJobs(jobs);
            return Ok();
        }

        // PUT api/<JobController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Job job)
        {
            var jobs = JobManagerRepository.GetJobs().ToList();

            var jobToUpdate = jobs.FirstOrDefault(p => p.Id == job.Id);
            if (jobToUpdate != null)
            {
                jobToUpdate.Name = job.Name;
                jobToUpdate.LicensePlate = job.LicensePlate;
                jobToUpdate.CarType = job.CarType;
                jobToUpdate.Date = job.Date;
                jobToUpdate.Failure = job.Failure;

                JobManagerRepository.StoreJobs(jobs);
                return Ok();
            }

            return NotFound();
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            List<Job> jobs = (List<Job>)JobManagerRepository.GetJobs();
            var jobToDelete = jobs.FirstOrDefault(x => x.Id == id);
            if(jobToDelete != null)
            {
                jobs.Remove(jobToDelete);
                JobManagerRepository.StoreJobs(jobs);
                return Ok();
            }
            return NotFound();
        }

        private int GetewId(IEnumerable<Job> jobs)
        {
            int newId = 0;
            foreach(var job in jobs)
            {
                if(newId < job.Id)
                {
                    newId = job.Id;
                }
            }

            return newId + 1;
        }
    }
}
