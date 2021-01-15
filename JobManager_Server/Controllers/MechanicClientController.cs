using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MechanicClient;
using JobManager_Server.Repositories;

namespace JobManager_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicClientController : ControllerBase
    {
        // GET: api/<MechanicClientController>
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            return Ok(MechanicClientRepository.GetJobs());
        }

        // PUT api/<MechanicClientController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Job job)
        {
            var jobs = JobManagerRepository.GetJobs().ToList();

            var jobToUpdate = jobs.FirstOrDefault(p => p.Id == job.Id);
            if (jobToUpdate != null)
            {
                jobToUpdate.State = job.State;

                JobManagerRepository.StoreJobs(jobs);
                return Ok();
            }

            return NotFound();
        }
    }
}
